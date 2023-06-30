Create database simpl_gestProduit;
Use simpl_gestProduit;

CREATE TABLE produits(
   id_produit INT AUTO_INCREMENT,
   desc_produit TEXT NOT NULL,
   nom_produit VARCHAR(50)  NOT NULL,
   estDisponible BOOLEAN NOT NULL,
   PRIMARY KEY(id_produit)
)engine=InnoDB;

CREATE TABLE images(
   id_image INT AUTO_INCREMENT,
   url_image VARCHAR(255)  NOT NULL,
   PRIMARY KEY(id_image)
)engine=InnoDB;

CREATE TABLE caracteristiques(
   id_carac INT AUTO_INCREMENT,
   nom_carac VARCHAR(50)  NOT NULL,
   estDisponible BOOLEAN NOT NULL,
   PRIMARY KEY(id_carac)
)engine=InnoDB;

CREATE TABLE options(
   id_option INT AUTO_INCREMENT,
   intituler_option VARCHAR(50)  NOT NULL,
   estDisponible BOOLEAN NOT NULL,
   id_carac INT NOT NULL,
   PRIMARY KEY(id_option),
   FOREIGN KEY(id_carac) REFERENCES caracteristiques(id_carac)
)engine=InnoDB;

CREATE TABLE categories(
   id_categorie INT AUTO_INCREMENT,
   nom_categorie VARCHAR(50)  NOT NULL,
   desc_categorie TEXT NOT NULL,
   PRIMARY KEY(id_categorie)
)engine=InnoDB;

CREATE TABLE promotions(
   id_promotion INT AUTO_INCREMENT,
   date_debut_promo DATETIME NOT NULL,
   date_fin_promo DATETIME NOT NULL,
   reduction_promo SMALLINT,
   PRIMARY KEY(id_promotion)
)engine=InnoDB;

CREATE TABLE prix(
   id_prix INT AUTO_INCREMENT,
   montant_prix DECIMAL(15,2)  ,
   PRIMARY KEY(id_prix)
)engine=InnoDB;

CREATE TABLE droits(
   id_droit INT AUTO_INCREMENT,
   nom_droit VARCHAR(50)  NOT NULL,
   PRIMARY KEY(id_droit)
)engine=InnoDB;

CREATE TABLE status(
   id_status INT AUTO_INCREMENT,
   intituler_status VARCHAR(50)  NOT NULL,
   PRIMARY KEY(id_status)
)engine=InnoDB;

CREATE TABLE villes(
   id_ville INT AUTO_INCREMENT,
   nom_ville VARCHAR(50)  NOT NULL,
   PRIMARY KEY(id_ville)
)engine=InnoDB;

CREATE TABLE code_postal(
   id_cp INT AUTO_INCREMENT,
   nombre_cp INT,
   id_ville INT,
   PRIMARY KEY(id_cp),
   FOREIGN KEY(id_ville) REFERENCES villes(id_ville)
)engine=InnoDB;

CREATE TABLE stocks(
   id_stock INT AUTO_INCREMENT,
   qte_stock INT NOT NULL,
   id_produit INT,
   id_prix INT,
   PRIMARY KEY(id_stock),
   FOREIGN KEY(id_produit) REFERENCES produits(id_produit),
   FOREIGN KEY(id_prix) REFERENCES prix(id_prix)
)engine=InnoDB;

CREATE TABLE remises(
   id_remise INT AUTO_INCREMENT,
   code_remise VARCHAR(10) ,
   réduction SMALLINT,
   estValide VARCHAR(50) ,
   id_stock INT,
   PRIMARY KEY(id_remise),
   FOREIGN KEY(id_stock) REFERENCES stocks(id_stock)
)engine=InnoDB;

CREATE TABLE comptes(
   id_compte INT AUTO_INCREMENT,
   login_compte VARCHAR(100)  NOT NULL,
   mdp_compte VARCHAR(100)  NOT NULL,
   nom_compte VARCHAR(50) ,
   prenom_compte VARCHAR(50) ,
   id_droit INT NOT NULL,
   PRIMARY KEY(id_compte),
   FOREIGN KEY(id_droit) REFERENCES droits(id_droit)
)engine=InnoDB;

CREATE TABLE avis(
   id_avis INT AUTO_INCREMENT,
   message_avis TEXT NOT NULL,
   date_avis DATETIME NOT NULL,
   id_stock INT,
   id_compte INT NOT NULL,
   PRIMARY KEY(id_avis),
   FOREIGN KEY(id_stock) REFERENCES stocks(id_stock),
   FOREIGN KEY(id_compte) REFERENCES comptes(id_compte)
)engine=InnoDB;

CREATE TABLE notes(
   id_note INT AUTO_INCREMENT,
   valeur_note SMALLINT NOT NULL,
   id_stock INT,
   id_compte INT,
   PRIMARY KEY(id_note),
   FOREIGN KEY(id_stock) REFERENCES stocks(id_stock),
   FOREIGN KEY(id_compte) REFERENCES comptes(id_compte)
)engine=InnoDB;

CREATE TABLE adresses(
   id_adresse INT AUTO_INCREMENT,
   numéro_adresse INT NOT NULL,
   voie_adresse VARCHAR(100) ,
   id_compte INT,
   PRIMARY KEY(id_adresse),
   FOREIGN KEY(id_compte) REFERENCES comptes(id_compte)
)engine=InnoDB;

CREATE TABLE expeditions(
   id_expedition INT AUTO_INCREMENT,
   adresse_expedition VARCHAR(255) ,
   date_expedition DATETIME NOT NULL,
   id_adresse INT,
   PRIMARY KEY(id_expedition),
   FOREIGN KEY(id_adresse) REFERENCES adresses(id_adresse)
)engine=InnoDB;

CREATE TABLE categoriser(
   id_produit INT,
   id_categorie INT,
   PRIMARY KEY(id_produit, id_categorie),
   FOREIGN KEY(id_produit) REFERENCES produits(id_produit),
   FOREIGN KEY(id_categorie) REFERENCES categories(id_categorie)
)engine=InnoDB;

CREATE TABLE promouvoir(
   id_categorie INT,
   id_promotion INT,
   PRIMARY KEY(id_categorie, id_promotion),
   FOREIGN KEY(id_categorie) REFERENCES categories(id_categorie),
   FOREIGN KEY(id_promotion) REFERENCES promotions(id_promotion)
)engine=InnoDB;

CREATE TABLE Profiter(
   id_remise INT,
   id_compte INT,
   PRIMARY KEY(id_remise, id_compte),
   FOREIGN KEY(id_remise) REFERENCES remises(id_remise),
   FOREIGN KEY(id_compte) REFERENCES comptes(id_compte)
)engine=InnoDB;

CREATE TABLE illustrer(
   id_image INT,
   id_stock INT,
   PRIMARY KEY(id_image, id_stock),
   FOREIGN KEY(id_image) REFERENCES images(id_image),
   FOREIGN KEY(id_stock) REFERENCES stocks(id_stock)
)engine=InnoDB;

CREATE TABLE etre(
   id_expedition INT,
   id_status INT,
   date_affectation DATETIME,
   PRIMARY KEY(id_expedition, id_status),
   FOREIGN KEY(id_expedition) REFERENCES expeditions(id_expedition),
   FOREIGN KEY(id_status) REFERENCES status(id_status)
)engine=InnoDB;

CREATE TABLE contenir(
   id_option INT,
   id_stock INT,
   PRIMARY KEY(id_option, id_stock),
   FOREIGN KEY(id_option) REFERENCES options(id_option),
   FOREIGN KEY(id_stock) REFERENCES stocks(id_stock)
)engine=InnoDB;

CREATE TABLE situer(
   id_adresse INT,
   id_ville INT,
   PRIMARY KEY(id_adresse, id_ville),
   FOREIGN KEY(id_adresse) REFERENCES adresses(id_adresse),
   FOREIGN KEY(id_ville) REFERENCES villes(id_ville)
)engine=InnoDB;

CREATE TABLE commander(
   id_stock INT,
   id_compte INT,
   id_expedition INT,
   qte_commander INT,
   PRIMARY KEY(id_stock, id_compte, id_expedition),
   FOREIGN KEY(id_stock) REFERENCES stocks(id_stock),
   FOREIGN KEY(id_compte) REFERENCES comptes(id_compte),
   FOREIGN KEY(id_expedition) REFERENCES expeditions(id_expedition)
)engine=InnoDB;
