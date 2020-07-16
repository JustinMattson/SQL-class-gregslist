/* CREATE TABLE cars(
 id INT NOT NULL AUTO_INCREMENT,
 make VARCHAR(255) NOT NULL,
 model VARCHAR(255) NOT NULL,
 imgUrl VARCHAR(255) NOT NULL,
 body VARCHAR(255) NOT NULL,
 price INT NOT NULL,
 productionYear INT NOT NULL,
 userId VARCHAR(255) NOT NULL,
 PRIMARY KEY (id)
) */


-- ALTER TABLE cars CHANGE productionYear year INT NOT NULL


USE gregslist6;
CREATE TABLE carfavorites
(
    id INT NOT NULL AUTO_INCREMENT,
    carId INT NOT NULL,
    user VARCHAR(255) NOT NULL,

    PRIMARY KEY (id),

    FOREIGN KEY (carId)
        REFERENCES cars (id)
        ON DELETE CASCADE
)
















































