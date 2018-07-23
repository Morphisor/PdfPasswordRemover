using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfPasswordRemover
{
    public static class PDFManager
    {
        public static string removePassword(string path, string password)
        {
            PdfReader.unethicalreading = true;
            var reader = new PdfReader(path, Encoding.ASCII.GetBytes(password));
            var mem = new MemoryStream();
            var stamper = new PdfStamper(reader, mem);
            stamper.SetEncryption(Encoding.ASCII.GetBytes(""), Encoding.ASCII.GetBytes(""), PdfWriter.AllowPrinting, PdfWriter.AllowScreenReaders | PdfWriter.AllowModifyContents);
            stamper.Close();
            reader.Close();
            var fileName = Path.GetFileName(path);
            fileName = $"{fileName}_Unlocked.pdf";
            File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, fileName), mem.ToArray());
            return fileName;
        }
    }
}

