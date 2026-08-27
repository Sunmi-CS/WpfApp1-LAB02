using System;
using System.Collections.Generic;
using System.Text;

using System.Windows;
using System.Windows.Input;
using WpfApp1.Views;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _usuario = "";
        private string _mensaje = "";

        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                OnPropertyChanged();
            }
        }

        public string Mensaje
        {
            get => _mensaje;
            set
            {
                _mensaje = value;
                OnPropertyChanged();
            }
        }

        public ICommand IngresarCommand { get; }

        public LoginViewModel()
        {
            IngresarCommand = new RelayCommand(Ingresar);
        }

        private void Ingresar(object? parameter)
        {
            if (Usuario == "admin" &&
                parameter is System.Windows.Controls.PasswordBox passwordBox &&
                passwordBox.Password == "1234")
            {
                Mensaje = "";

                // Crear servicio compartido en memoria
                var service = new AppDataService();

                MenuWindow ventana = new MenuWindow(service);

                Application.Current.MainWindow = ventana;

                ventana.Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is LoginWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            else
            {
                Mensaje = "Usuario o contraseña incorrectos.";
            }
        }
    }
}
