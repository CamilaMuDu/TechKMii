using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Reportes
{
    public partial class frmReporteGrafico : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private readonly IFacturaBLL facturaBLL = new FacturaBLL();

        public frmReporteGrafico()
        {
            InitializeComponent();
        }

        private void btnGuardarGrafico_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Seleccione el Directorio";
                dialog.FileName = "GraficoVentas.png";
                dialog.Filter = "Imagen PNG|*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    chartVentas.SaveImage(dialog.FileName, ChartImageFormat.Png);

                    MessageBox.Show("Gráfico guardado correctamente.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Error al guardar el gráfico: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReporteGrafico_Load(object sender, EventArgs e)
        {

            dtpFechaInicial.Value = DateTime.Today;
            dtpFechaFinal.Value = DateTime.Today;

            cmbTipoGrafico.Items.Clear();
            cmbTipoGrafico.Items.Add("Columnas");
            cmbTipoGrafico.Items.Add("Líneas");
            cmbTipoGrafico.Items.Add("Barras");
            cmbTipoGrafico.Items.Add("Pastel");
            cmbTipoGrafico.Items.Add("Donas");
            cmbTipoGrafico.Items.Add("Área");
            cmbTipoGrafico.Items.Add("Curva Suave");
            cmbTipoGrafico.SelectedIndex = 0;

            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Titles.Clear();

            chartVentas.ChartAreas.Add(new ChartArea("ChartArea1"));
            chartVentas.Series.Add("Series1");

        }

        private void btnMostrarGrafico_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = dtpFechaInicial.Value.Date;
                DateTime fechaFinal = dtpFechaFinal.Value.Date;

                if (fechaInicial > fechaFinal)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var listaFacturas = facturaBLL.GetAll().ToList();

                var ventasAgrupadas = listaFacturas
                    .Where(f => f.Fecha.Date >= fechaInicial && f.Fecha.Date <= fechaFinal)
                    .GroupBy(f => f.Fecha.Date)
                    .Select(g => new
                    {
                        Fecha = g.Key,
                        TotalVenta = g.Sum(x => x.TotalCRC)
                    })
                    .OrderBy(x => x.Fecha)
                    .ToList();

                if (ventasAgrupadas.Count == 0)
                {
                    MessageBox.Show("No hay ventas en ese rango de fechas.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Fecha", typeof(string));
                dt.Columns.Add("TotalVenta", typeof(double));

                foreach (var item in ventasAgrupadas)
                {
                    dt.Rows.Add(item.Fecha.ToString("dd/MM/yyyy"), item.TotalVenta);
                }

                chartVentas.Series.Clear();
                chartVentas.ChartAreas.Clear();
                chartVentas.Titles.Clear();

                chartVentas.ChartAreas.Add(new ChartArea("ChartArea1"));
                chartVentas.Series.Add("Series1");

                chartVentas.DataSource = dt;
                chartVentas.Series["Series1"].XValueMember = "Fecha";
                chartVentas.Series["Series1"].YValueMembers = "TotalVenta";

                chartVentas.Titles.Add("Ventas por Rango de Fecha");
                chartVentas.Titles[0].Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                chartVentas.Series["Series1"].IsValueShownAsLabel = true;
                chartVentas.Series["Series1"].LabelFormat = "N2";

                if (cmbTipoGrafico.SelectedIndex == 0)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Column;
                if (cmbTipoGrafico.SelectedIndex == 1)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Line;
                if (cmbTipoGrafico.SelectedIndex == 2)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Bar;
                if (cmbTipoGrafico.SelectedIndex == 3)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Pie;
                if (cmbTipoGrafico.SelectedIndex == 4)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Doughnut;
                if (cmbTipoGrafico.SelectedIndex == 5)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Area;
                if (cmbTipoGrafico.SelectedIndex == 6)
                    chartVentas.Series["Series1"].ChartType = SeriesChartType.Spline;

                chartVentas.DataBind();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrafico(List<dynamic> ventasPorFecha)
        {
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Titles.Clear();

            ChartArea area = new ChartArea("AreaVentas");
            area.AxisX.Title = "Fecha";
            area.AxisY.Title = "Total Ventas CRC";
            area.AxisX.Interval = 1;
            chartVentas.ChartAreas.Add(area);

            Series serie = new Series("Ventas");

            if (cmbTipoGrafico.SelectedItem != null && cmbTipoGrafico.SelectedItem.ToString() == "Lineas")
                serie.ChartType = SeriesChartType.Line;
            else
                serie.ChartType = SeriesChartType.Column;

            serie.IsValueShownAsLabel = true;

            foreach (var item in ventasPorFecha)
            {
                serie.Points.AddXY(item.Fecha.ToString("dd/MM/yyyy"), item.TotalVentas);
            }

            chartVentas.Series.Add(serie);
            chartVentas.Titles.Add("Gráfico de Ventas por Fecha");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
