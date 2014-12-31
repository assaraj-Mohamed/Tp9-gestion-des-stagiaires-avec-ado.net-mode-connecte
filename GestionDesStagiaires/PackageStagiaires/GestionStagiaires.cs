using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PackageStagiaires
{
    public class GestionStagiaires{
       private static List<Stagiaire> listeStagiaires = new List<Stagiaire>();
       public void Ajouter(Stagiaire s)
       {
           string connexionString, requete;
           connexionString = @"Data Source=localhost;Initial Catalog=GestionStagiaires;User= 'sa'; password = 'admintp4'";
           requete = "Insert into Stagiaires(Id,Nom,Prenom) values(" + s.Id + ",'" + s.Nom + "','" + s.Prenom + "');";
           MessageBox.Show(requete);
           SqlConnection connexion = new SqlConnection(connexionString);
           SqlCommand commande = connexion.CreateCommand();
           commande.CommandText = requete;
           connexion.Open(); commande.ExecuteNonQuery(); connexion.Close();
       }
       public void Supprimer(int id)
       {
           string connexionString, requete;
           connexionString = @"Data Source=localhost;Initial Catalog=GestionStagiaires;User= 'sa'; password = 'admintp4'";
           requete = "delete from Stagiaires where Id = " + id + ";";
           MessageBox.Show(requete);
           SqlConnection connexion = new SqlConnection(connexionString);
           SqlCommand commande = connexion.CreateCommand();
           commande.CommandText = requete;
           connexion.Open();
           commande.ExecuteNonQuery();
           connexion.Close();
       }
       public void Modifier(Stagiaire s)
       {
           string connexionString, requete;
           connexionString = @"Data Source=localhost;Initial Catalog=GestionStagiaires;User= 'sa'; password = 'admintp4'";
           requete = "update Stagiaires set Nom = '" + s.Nom + "' ,  Prenom = '" + s.Prenom + "' where id = " + s.Id + ";";
           MessageBox.Show(requete);
           SqlConnection connexion = new SqlConnection(connexionString);
           SqlCommand commande = connexion.CreateCommand();
           commande.CommandText = requete;
           connexion.Open();
           commande.ExecuteNonQuery();
           connexion.Close();
       }
       public List<Stagiaire> Afficher()
       {
           List<Stagiaire> ls = new List<Stagiaire>();
           string connexionString, requete;
           connexionString = @"Data Source=localhost;Initial Catalog=GestionStagiaires;User= 'sa'; password = 'admintp4'";
           requete = "SELECT * FROM Stagiaires";
           SqlConnection connexion = new SqlConnection(connexionString);
           SqlCommand commande = connexion.CreateCommand();
           commande.CommandText = requete;
           connexion.Open();
           SqlDataReader lire = commande.ExecuteReader();
           while (lire.Read())
           {
               ls.Add(new Stagiaire(lire.GetInt32(0), lire.GetString(1), Convert.ToString(lire["Prenom"])));

           }
           connexion.Close();


           return ls;
       }
       public Stagiaire getStagiaire(int id)
       {
           List<Stagiaire> ls = new List<Stagiaire>();
           string connexionString, requete;
           connexionString = @"Data Source=localhost;Initial Catalog=GestionStagiaires;User= 'sa'; password = 'admintp4'";
           requete = "SELECT * FROM Stagiaires where id = " + id;
           SqlConnection connexion = new SqlConnection(connexionString);
           SqlCommand commande = connexion.CreateCommand();
           commande.CommandText = requete;
           connexion.Open();
           SqlDataReader lire = commande.ExecuteReader();
           while (lire.Read())
           {
               ls.Add(new Stagiaire(lire.GetInt32(0), lire.GetString(1), Convert.ToString(lire["Prenom"])));

           }
           connexion.Close();
           return ls.ElementAt(0);
       }
    
    }
}
