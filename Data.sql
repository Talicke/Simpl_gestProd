use simpl_products;

INSERT INTO produits (nom_produit, desc_produit, estDisponible) values
('Chemise 1', 'Chemise jolie', true),
('Chemise 2', 'Chemise ordinaire', true),
('Chemise 3', 'Chemise moche', true),
('Chemise 4', 'Chemise hiddeuse', true),
('Jeans 1', 'Jeans jolie', true),
('Jeans 2', 'Jeans ordinaire', true),
('Jeans 3', 'Jeans moche', true),
('Jeans 4', 'Jeans hiddeux', true),
('Pull 1', 'Pull jolie', true),
('Pull 2', 'Pull ordinaire', true),
('Pull 3', 'Pull moche', true),
('Pull 4', 'Pull hiddeux', true),
('Polo 1', 'Polo jolie', true),
('Polo 2', 'Polo oridnaire', true),
('Polo 3', 'Polo moche', true),
('Polo 4', 'Polo hiddeux', true);

INSERT INTO images (url_image) values
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300'),
('https://picsum.photos/200/300');

INSERT INTO caracteristiques(nom_carac, estDisponible) values
('couleur', true),
('taille', true),
('coupe', true),
('occasion', true);

INSERT INTO `options`(intituler_option, estDisponible, id_carac) values
('bleu', true, 1),
('vert', true, 1),
('jaune', false, 1),
('XL', true, 2),
('L', false, 2),
('S', true, 2),
('droite', true, 3),
('cintré', true, 3),
('evasé', true, 3),
('oui', true, 4),
('non', false, 4);

insert into categories(nom_categories, desc_categorie) values
('haut', 'vetement pour le haut du corps'),
('bas', 'vetement pour le bas du corps'),
('homme', 'vetement pour homme'),
('femme', 'vetement pour femme'),
('noel', 'vetement de noel');



