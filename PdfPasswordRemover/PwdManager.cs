using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfPasswordRemover
{
    public class PwdManager
    {
        private static PwdManager instance;

        public static PwdManager Instance
        {
            get
            {
                lock (typeof(PwdManager))
                {
                    if (instance == null)
                    {
                        instance = new PwdManager();
                    }

                    return instance;
                }
            }
        }

        public string Password { get; private set; }
        public bool isPasswordSet
        {
            get
            {
                return !string.IsNullOrEmpty(Password);
            }
        }

        private readonly string _filePath;

        private PwdManager()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, "password.txt");
            if (File.Exists(_filePath))
            {
                Password = File.ReadAllText(_filePath);
            } else
            {
                File.Create(_filePath).Close();
            }
        }

        public void SetPassword(string newPassword)
        {
            File.WriteAllText(_filePath, newPassword);
            Password = newPassword;
        }
    }
}
