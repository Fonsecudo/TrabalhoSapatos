﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using TrabalhoSapatos.Control;

namespace InterfaceGrafica
{
    /// <summary>
    /// Lógica interna para WindowVenda.xaml
    /// </summary>
    public partial class WindowVenda : Window
    {
        PessoaController pessoaController = new PessoaController();

        public WindowVenda(string cnpjParameter = null, string cpfParameter = null)
        {
            InitializeComponent();
            if (cnpjParameter != null)
            {
                cnpj.Text = cnpjParameter;
            }
            if (cpfParameter != null)
            {
                cpf.Text = cpfParameter;
            }
        }

        private void cadastro_pessoa_cpf (object sender, RoutedEventArgs e)
        {
            if (cpf.Text != null)
            {
                var pessoa = pessoaController.buscarPessoaFisica(cpf.Text);
                if (pessoa != null)
                {
                    WindowVendaProduto windowProduto = new WindowVendaProduto(pessoa.nome);
                    this.Close();
                    windowProduto.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Este cliente não existe no sistema, favor cadastra-lo !");
                    WindowCadastroPessoaFisica windowFisica = new WindowCadastroPessoaFisica(cpf.Text);
                    this.Close();
                    windowFisica.ShowDialog();
                }
                    // var itemExcluido = modelSapato.sapatos.Where(s => s.id == id).Single();
            }
            else
            {
                MessageBox.Show("Por favor, insira um CPF");
            }
        }

        private void cadastro_pessoa_cnpj(object sender, RoutedEventArgs e)
        {
            if (cnpj.Text != null)
            {
                var pessoa = pessoaController.buscarPessoaJuridica(cnpj.Text);
                if (pessoa != null)
                {
                    WindowVendaProduto windowProduto = new WindowVendaProduto(pessoa.nome);
                    this.Close();
                    windowProduto.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Este cliente não existe no sistema, favor cadastra-lo !");
                    WindowCadastroPessoaJuridica windowJuridica = new WindowCadastroPessoaJuridica(cnpj.Text);
                    this.Close();
                    windowJuridica.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um CNPJ");
            }
        }
    }
}
