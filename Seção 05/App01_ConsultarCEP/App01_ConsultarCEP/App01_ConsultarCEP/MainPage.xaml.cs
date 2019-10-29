﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs e)
        {

            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end != null) {
                        RESULTADO.Text = string.Format("Endereço: {2} {3} {0}, {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    } else
                    {
                        DisplayAlert("ERRO", "CEP Inválido!  O CEP verifique se digitou o número corretamente", "OK");
                    }
                    
                   
                }
                catch (Exception ex)
                {

                    DisplayAlert("ERRO CRITICO", ex.Message, "OK");
                }
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            int NovoCEP = 0;
           if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido!  O CEP deve conter 8 caracteres", "OK");
                valido = false;
            }

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido!  O CEP deve conter apenas caracteres numéricos", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
