using System;
using System.Collections.Generic;
using System.Text;

namespace ACT7_CourseLevriers
{
    internal class User
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private int _monnaie;

		public int Monnaie
		{
			get { return _monnaie; }
			set { _monnaie = value; }
		}

		public User(string name, int monnaie)
		{
			this._name = name;
			this._monnaie = monnaie;
		}

		// faire les fonctions de jeux

		public void placerPari(int somme, int numberChien)
		{
			Pari pariUser = new Pari(somme,Name,numberChien);
		}

		public void soustraireArgent(int somme)
		{
			Monnaie = Monnaie - somme;
		}

		public void ajouterArgent(int somme)
		{
			Monnaie = Monnaie + (somme * 2);
		}


	}
}
