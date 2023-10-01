using CustomComponent.Helpers;
using CustomComponent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace CustomComponent
{
    public partial class ComponentDiagramToPdf : Component
    {

        private Document _document;
        private Table _table;
        private Chart _chart;

        private Document Document
        {
            get
            {
                if (this._document == null)
                {
                    this._document = new Document();
                }
                return this._document;
            }
        }

        private Table Table
        {
            get
            {
                if (this._table == null)
                    this._table = new Table();
                return this._table;
            }
        }

        public ComponentDiagramToPdf()
        {
            InitializeComponent();
        }

        public ComponentDiagramToPdf(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateHeader(string header)
        {
            var section = this.Document.AddSection();
            var paragraph = section.AddParagraph(header);
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.Font.Bold = true;
        }
        private void ConfigChart(ComponentDiagramToPdfConfig config)
        {
            ((Shape)this._chart).Width = Unit.FromCentimeter(16.0);
            ((Shape)this._chart).Height = Unit.FromCentimeter(12.0);
            this._chart.TopArea.AddParagraph(config.ChartTitle);
            this._chart.XAxis.MajorTickMark = (TickMarkType)2;
            this._chart.YAxis.MajorTickMark = (TickMarkType)2;
            this._chart.YAxis.HasMajorGridlines = true;
            this._chart.PlotArea.LineFormat.Width = new Unit(1);
            this._chart.PlotArea.LineFormat.Visible = true;
            switch (config.LegendLocation)
            {
                case Location.Left:
                    this._chart.LeftArea.AddLegend();
                    break;
                case Location.Rigth:
                    this._chart.RightArea.AddLegend();
                    break;
                case Location.Top:
                    this._chart.TopArea.AddLegend();
                    break;
                case Location.Bottom:
                    this._chart.BottomArea.AddLegend();
                    break;
            }
        }

        public void CreateLineChart(ComponentDiagramToPdfConfig config)
        {
            this._chart = new Chart((ChartType)0);
            foreach (string key in config.Data.Keys)
            {
                Series series = this._chart.SeriesCollection.AddSeries();
                series.Name = key;
                series.Add(config.Data[key].Select(x => x.Item2).ToArray());
            }
            this._chart.XValues.AddXSeries().Add(config.Data.First().Value.Select(x => x.Item1.ToString()).ToArray());
            this.ConfigChart(config);
        }

        public void SaveDoc(string filepath)
        {
            if (filepath.IsEmpty())
                throw new ArgumentNullException("Имя файла не задано");
            if (this._document == null)
                throw new ArgumentNullException("Документ не сформирован, сохранять нечего");
            if (this._table != null)
                this._document.LastSection.Add(this._table);
            if (this._chart != null)
                this._document.LastSection.Add(this._chart);
            PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(true)
            {
                Document = this._document
            };
            documentRenderer.RenderDocument();
            documentRenderer.PdfDocument.Save(filepath);
        }

        public void CreateDoc(ComponentDiagramToPdfConfig config)
        {
            config.CheckFields();
            CreateHeader(config.Header);
            CreateLineChart(config);
            SaveDoc(config.FilePath);
        }
    }
}
