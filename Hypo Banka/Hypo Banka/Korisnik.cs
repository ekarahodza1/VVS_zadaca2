﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hypo_Banka
{
    public abstract class Korisnik
    {
        #region Atributi

        static int brojač = 0;
        int id;
        string ime, prezime, korisnickoIme, lozinka;

        #endregion

        #region Properties

        public int Id
        {
            get => id;
        }

        public string Ime
        {
            get => ime;
            set
            {
                if (value == null || value.Length < 1
                    || !(value.Substring(0, 1).All(char.IsUpper)
                    && value.Substring(1).All(char.IsLower)))
                    throw new ArgumentException("Ime je neispravno!");

                ime = value;
            }
        }

        public string Prezime
        {
            get => prezime;
            set
            {
                if (value == null || value.Length < 1
                    || !(value.Substring(0, 1).All(char.IsUpper)
                    && value.Substring(1).All(char.IsLower)))
                    throw new ArgumentException("Prezime je neispravno!");

                prezime = value;
            }
        }
        public string KorisnickoIme
        {
            get => korisnickoIme;
            set
            {
                if (value == null || value.Length < 1)
                    throw new ArgumentException("Korisničko ime je neispravno!");

                korisnickoIme = value;
            }
        }
        public string Lozinka
        {
            get => lozinka;
            set
            {
                if (value == null || value.Length < 20
                    || value.Any(char.IsWhiteSpace) || value.All(char.IsLetterOrDigit))
                    throw new ArgumentException("Lozinka je neispravna!!");

                byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                lozinka = System.Text.Encoding.ASCII.GetString(data);
            }
        }

        #endregion

        #region Konstruktor

        public Korisnik(string name, string surname, string username, string password)
        {
            Ime = name;
            Prezime = surname;
            KorisnickoIme = username;
            Lozinka = password;

            brojač++;
            id = brojač;
        }

        public Korisnik()
        {

        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda u kojoj se automatski generišu korisničko ime i lozinka za korisnika.
        /// Ukoliko ime i prezime korisnika nisu postavljeni, baca se izuzetak.
        /// U suprotnom, generiše se korisničko ime formata prvoslovoimenaprezime1.
        /// Password se generiše prema dozvoljenom formatu podataka iz settera po želji.
        /// Korisničko ime i hashirani password vraćaju se kao rezultat metode.
        /// </summary>
        
        /// Dženana, Esma
        public Tuple<string, string> AutomatskoGenerisanjePodataka()
        {
            if (Ime == null || Prezime == null) throw new Exception("Ime ili prezime korisnika nisu postavljeni"); //ne moze se doci do ovog izuzetka 
            string korisnickoIme = Ime.Substring(0, 1).ToLower() + Prezime.ToLower() + "1";
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwxyz0123456789";
            string password = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            password += "#";
            Lozinka = password;
            KorisnickoIme = korisnickoIme;
            Tuple<string, string> tuple = new Tuple<string, string>(korisnickoIme, password);
            return tuple;
        }

        #endregion
    }
}
