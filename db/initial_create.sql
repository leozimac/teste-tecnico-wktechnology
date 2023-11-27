CREATE TABLE IF NOT EXISTS categories (
	id				INT UNIQUE AUTO_INCREMENT,
	name			VARCHAR(80) NOT NULL,
	description		VARCHAR(255),

	CONSTRAINT pk_category PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS products (
	id				INT UNIQUE AUTO_INCREMENT,
	name			VARCHAR(80) NOT NULL,
	description		VARCHAR(255),
	price			DECIMAL(6,2) NOT NULL,
	id_category		INT NOT NULL,

	CONSTRAINT pk_products PRIMARY KEY (id),
	CONSTRAINT fk_category_product FOREIGN KEY (id_category) REFERENCES categories(id)
);