using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.Charts;

namespace TVMS.Computation
{
    public class PlotGraph
    {
        private string GetTemplate()
        {
            var webClient = new WebClient();
            var link = new Uri(@"https://psv4.vk.me/c810528/u115256989/docs/785e7143791b/population.crtx");
            string path = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\population.crtx";
            webClient.DownloadFileAsync(link, path);
            return path;
        }

        public PlotGraph(double[] x, double[] y, double k, double b)
        {
            string path = GetTemplate();
            var n = x.Length.ToString();
            object misValue = Missing.Value;
            var graph = new Excel.Application() {Visible = true};
            var workbook = graph.Workbooks.Add(misValue);
            var worksheet = (Excel.Worksheet) workbook.Worksheets.Item[1];
            worksheet.Cells[1, 1] = "";
            worksheet.Cells[1, 2] = "";
            worksheet.Cells[1, 3] = "";
            worksheet.Cells[1, 4] = "";

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j <= x.Length; j++)
                {
                    switch (i)
                    {
                        case 1:
                            worksheet.Cells[j, i] = x[j - 1];
                            break;
                        case 2:
                            worksheet.Cells[j, i] = y[j - 1];
                            break;
                        case 3:
                            worksheet.Cells[j, i] = x[j - 1];
                            break;
                        case 4:
                            worksheet.Cells[j, i] = k*x[j - 1] + b;
                            break;
                    }
                }
            }
            Excel.Range range;

            var excelCharts = (Excel.ChartObjects) worksheet.ChartObjects(Type.Missing);
            var chart = excelCharts.Add(10, 80, 500, 300);
            var chartPage = chart.Chart;

            
            chartPage.ApplyChartTemplate(path); //Используем шаблон

            

            //Коллекция данных
            Excel.SeriesCollection seriesCollection = chart.Chart.SeriesCollection();
            
            //Данные выборки
            Excel.Series defaultSeries = seriesCollection.NewSeries();

            defaultSeries.ChartType = Excel.XlChartType.xlXYScatter;

            defaultSeries.XValues = worksheet.Range["A1", "A" + n];
            defaultSeries.Values = worksheet.Range["B1", "B" + n];
            defaultSeries.MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleCircle;

            //Данные полученных значений
            var plotedSeries = seriesCollection.NewSeries();
            plotedSeries.XValues = worksheet.Range["C1", "C" + n];
            plotedSeries.Values = worksheet.Range["D1", "D" + n];
            plotedSeries.MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleCircle;

            chartPage.HasLegend = true;
            chartPage.Legend.LegendEntries(1).Delete();
            chartPage.Legend.LegendEntries(1).Delete();

            var counter = 1;
            foreach (Excel.Series series in chartPage.SeriesCollection())
            {
                series.Name = counter++ == 3 ? "Данные выборки" : "Функция регрессии";
            }

            chartPage.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
            foreach (Excel.ChartObject co in excelCharts)
            {
                co.Select();
                Excel.Chart thisChart = (Excel.Chart)co.Chart;
                thisChart.Export(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\chart.png", "PNG", false);
            }

            workbook.Close(false, misValue, misValue);
            graph.Quit();
        }
    }
}