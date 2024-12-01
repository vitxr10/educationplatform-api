using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EducationPlatform.Application.Common
{
    public class PdfService : IPdfService
    {
        public byte[] CreatePdf(string userFullName, string courseName)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                var attachmentBytes =
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(50);
                        page.PageColor(Colors.Purple.Darken2);
                        page.DefaultTextStyle
                        (
                             x => x
                             .FontSize(20)
                             .FontColor(Colors.White)
                        );

                        page.Header()
                            .AlignCenter()
                            .Text("Certificado")
                            .SemiBold()
                            .FontSize(35);

                        page.Content()
                            .AlignCenter()
                            .AlignMiddle()
                                        .Column(column =>
                                        {
                                            column.Item().AlignCenter().Text(userFullName).FontSize(25);

                                            column.Item().PaddingTop(10);
                                            column.Item().LineHorizontal(2).LineColor(Colors.White);
                                            column.Item().PaddingBottom(10);

                                            column.Item().AlignCenter().Text("Concluiu sua participação no curso").FontSize(25);
                                            column.Item().AlignCenter().Text(courseName).Bold().FontSize(25);
                                            column.Item().AlignCenter().Text("com carga horária de 8 horas").FontSize(25);
                                            column.Item().AlignCenter().Text("na data de " + DateTime.Now.ToShortDateString()).FontSize(25);
                                        });

                        page.Footer()
                        .AlignCenter()
                        .Text("Vitxr Cursos e Treinamentos")
                        .FontSize(25);
                    });
                })
                .GeneratePdf();

                return attachmentBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}