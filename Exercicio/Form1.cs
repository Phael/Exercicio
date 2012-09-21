﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 


namespace Exercicio
{    

    public partial class Form_Principal : Form
    {
        Dictionary<string, List<Filmes>> DICIONARIO = new Dictionary<string, List<Filmes>>();
        List<Filmes> LISTA_FILMES = new List<Filmes>();

        public Form_Principal()
        {
            InitializeComponent();
        }



        public void Limpar()
        {
            textBox_Nome.Text = string.Empty;
            comboBox_Genero.Text = string.Empty;
            textBox_Local.Text = string.Empty;

        }

        public void Adicionar()
        {
            Filmes Filme = new Filmes();
            List<Filmes> LISTA = new List<Filmes>();
            ListViewItem LISTA_VIEW = new ListViewItem();

            if ((textBox_Nome.Text != string.Empty) && (comboBox_Genero.Text != string.Empty) && (textBox_Local.Text != string.Empty))
            {
                    //Adiciona o FIlme a Lista e ao Dicionario
                    

                 if(DICIONARIO.ContainsKey(comboBox_Genero.Text))
                 {
                     List<Filmes> FILMESREF = DICIONARIO[comboBox_Genero.Text];
                     LISTA.Add(Filme);

                     Filme.NOME_FILME = textBox_Nome.Text;
                     Filme.GENERO = comboBox_Genero.Text;
                     Filme.LOCAL = textBox_Local.Text;
                     Filme.DATA = dateTimePicker_Data.Value.ToShortDateString();
                     LISTA_FILMES.Add(Filme);

                     DICIONARIO.Add(comboBox_Genero.Text, LISTA_FILMES);
                 }
                 else
                 {
                    List<Filmes> LISTAREFERENCIA = new List<Filmes>();

                    Filme.NOME_FILME = textBox_Nome.Text;
                    Filme.GENERO = comboBox_Genero.Text;
                    Filme.LOCAL = textBox_Local.Text;
                    Filme.DATA = dateTimePicker_Data.Value.ToShortDateString();
                    LISTA_FILMES.Add(Filme);

                    DICIONARIO.Add(comboBox_Genero.Text, LISTA_FILMES);
                 }
                 
                    //Adiciona valores no lisView_roll
                    LISTA_VIEW.Text = Filme.NOME_FILME;
                    LISTA_VIEW.SubItems.Add(Filme.GENERO);
                    LISTA_VIEW.SubItems.Add(Filme.LOCAL);
                    LISTA_VIEW.SubItems.Add(Filme.DATA);
                    LISTA_VIEW.Group = listView_roll.Groups[comboBox_Genero.Text];
                    listView_roll.Items.Add(LISTA_VIEW);

                    
               
                //Limpar();
            }
            else
            {
                MessageBox.Show("Preencha todos os Campos", "Campos Nao Preenchidos", MessageBoxButtons.OK);
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
            
        }
        public void comboBox_Genero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            comboBox_Genero.DataSource = listView_roll.Groups;
        }

        public void button_Adicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
            //foreach (KeyValuePair<string, List<Filmes>> J in DICIONARIO)
            //{
            //    foreach (Filmes JJ in J.Value)
            //    {
            //        MessageBox.Show("" + Filme.NOME_FILME + Filme.LOCAL + Filme.DATA + Filme.GENERO, "" + J.Key, MessageBoxButtons.OK);
            //    }
            //}
            
        
        }

    }

}

