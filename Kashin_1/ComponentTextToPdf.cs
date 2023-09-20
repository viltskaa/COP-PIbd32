using CustomComponent.Helpers;
using CustomComponent.Models;
using DocumentFormat.OpenXml.Wordprocessing;
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
        private Body _body = null;

        private Document _document = null;

        private List<string> _texts = null;

        public ComponentTextToPdf()
        {
            InitializeComponent();
        }

        public ComponentTextToPdf(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private ICreatorWithContext creator;

        protected virtual ICreatorWithContext GetCreator()
        {
            return creator;
        }

        private List<string> Texts
        {
            get
            {
                if (_texts == null)
                {
                    _texts = new List<string>();
                }

                return _texts;
            }
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

        private Body Body
        {
            get
            {
                if (_body == null)
                {
                    _body = Document.AppendChild(new Body());
                }

                return _body;
            }
        }

        public void CreateDoc(ComponentTextToPdfConfig config)
        {
            config.CheckFields();
            CreateHeader(config.Header);
            foreach (string paragraph in config.Paragraphs)
            {
                CreateParagraph(paragraph);
            }

            creator.SaveDoc(config.FilePath);
        }

         public void CreateHeader(string header)
        {
            DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
            DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
            run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
            run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(header));
        }

        public void CreateParagraph(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("Текст не загружен");
            }

            Texts.Add(text);
        }


    }
}
