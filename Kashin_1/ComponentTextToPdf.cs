using CustomComponent.Helpers;
using CustomComponent.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent
{
    public partial class ComponentTextToPdf : Component
    {
        private Document _document;
        private Table _table;
        private Chart _chart;

        public ComponentTextToPdf()
        {
            InitializeComponent();
        }

        public ComponentTextToPdf(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private Document Document
        {
            get
            {
                if (_document == null)
                {
                    _document = new Document();
                }

                return _document;
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

        public void CreateDoc(ComponentTextToPdfConfig config)
        {
            config.CheckFields();
            CreateHeader(config.Header);
            foreach (string paragraph in config.Paragraphs)
            {
                CreateParagraph(paragraph);
            }

            SaveDoc(config.FilePath);
        }

        public void CreateHeader(string header)
        {
            var section = this.Document.AddSection();
            var paragraph = section.AddParagraph(header);
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.Font.Bold = true;
        }

        public void CreateParagraph(string text) => this.Document.LastSection.AddParagraph(text, "Normal");

    }
}
