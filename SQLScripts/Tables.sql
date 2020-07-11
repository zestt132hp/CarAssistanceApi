CREATE TABLE "Manufacters" (
	"Id" serial NOT NULL,
	"Brand" varchar(40) NOT NULL,
	CONSTRAINT Manufacters_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Models" (
	"Id" serial NOT NULL,
	"ModelName" varchar(150) NOT NULL,
	"YearStart" integer NOT NULL,
	"YearEnd" integer NOT NULL,
	CONSTRAINT Models_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "BodyType" (
	"Id" serial NOT NULL,
	"BodyType" varchar(150) NOT NULL DEFAULT 'null',
	CONSTRAINT BodyType_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "GearBoxes" (
	"Id" serial NOT NULL,
	"GearBoxType" varchar(150) NOT NULL DEFAULT 'null',
	"CountGears" integer NOT NULL,
	"NumberGearBox" varchar(150) NOT NULL DEFAULT 'null',
	"VehicleDrive_Id" integer NOT NULL,
	CONSTRAINT GearBoxes_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "VehicleDrive" (
	"Id" serial NOT NULL,
	"TypeVehicleDrive" varchar(150) NOT NULL,
	CONSTRAINT VehicleDrive_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Engine" (
	"Id" serial NOT NULL,
	"EngineNumber" varchar(150),
	"Fuel_Id" integer NOT NULL,
	"Count_HorsePower" integer,
	"Сount_kWt" integer,
	"Capacity_Engine" FLOAT NOT NULL,
	CONSTRAINT Engine_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Fuel" (
	"Id" serial NOT NULL,
	"FuelType" varchar(150) NOT NULL DEFAULT 'null',
	CONSTRAINT Fuel_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Car" (
	"Id" serial NOT NULL,
	"Car_Name_Id" integer NOT NULL,
	"Engine_Id" integer NOT NULL,
	"GearBoxes_Id" integer NOT NULL,
	"BodyType_Id" integer NOT NULL,
	"Car_Charcs_Id" integer NOT NULL,
	"Tires_Id" integer NOT NULL,
	CONSTRAINT Car_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "CarName" (
	"Manufacters_Id" integer NOT NULL,
	"Models_Id" integer NOT NULL,
	"Id" serial NOT NULL,
	CONSTRAINT CarName_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Car_Characteristics" (
	"Id" serial NOT NULL,
	"Mileage_Register" integer NOT NULL,
	"Oil_Info" varchar,
	"Mileage_Now" integer NOT NULL,
	CONSTRAINT Car_Characteristics_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Tires" (
	"Id" serial NOT NULL,
	"TiresSeason_Id" integer NOT NULL,
	"YearStartSales" integer NOT NULL,
	"Brand" varchar,
	"height" integer NOT NULL,
	"width" integer NOT NULL,
	"Radius" integer NOT NULL,
	CONSTRAINT Tires_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TiresSeason" (
	"Id" serial NOT NULL,
	"Season" varchar NOT NULL,
	CONSTRAINT TiresSeason_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Garage" (
	"Id" serial NOT NULL,
	"NameUser" varchar NOT NULL,
	"UserPassword" varchar NOT NULL,
	"Car_Id" integer NOT NULL,
	"DateRegister" DATE NOT NULL,
	"Notes" varchar,
	CONSTRAINT Garage_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Assistance" (
	"Id" serial NOT NULL,
	"Garage_Id" integer NOT NULL,
	CONSTRAINT Assistance_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);






ALTER TABLE "GearBoxes" ADD CONSTRAINT "GearBoxes_fk0" FOREIGN KEY ("VehicleDrive_Id") REFERENCES "VehicleDrive"("Id");


ALTER TABLE "Engine" ADD CONSTRAINT "Engine_fk0" FOREIGN KEY ("Fuel_Id") REFERENCES "Fuel"("Id");


ALTER TABLE "Car" ADD CONSTRAINT "Car_fk0" FOREIGN KEY ("Car_Name_Id") REFERENCES "CarName"("Id");
ALTER TABLE "Car" ADD CONSTRAINT "Car_fk1" FOREIGN KEY ("Engine_Id") REFERENCES "Engine"("Id");
ALTER TABLE "Car" ADD CONSTRAINT "Car_fk2" FOREIGN KEY ("GearBoxes_Id") REFERENCES "GearBoxes"("Id");
ALTER TABLE "Car" ADD CONSTRAINT "Car_fk3" FOREIGN KEY ("BodyType_Id") REFERENCES "BodyType"("Id");
ALTER TABLE "Car" ADD CONSTRAINT "Car_fk4" FOREIGN KEY ("Car_Charcs_Id") REFERENCES "Car_Characteristics"("Id");
ALTER TABLE "Car" ADD CONSTRAINT "Car_fk5" FOREIGN KEY ("Tires_Id") REFERENCES "Tires"("Id");

ALTER TABLE "CarName" ADD CONSTRAINT "CarName_fk0" FOREIGN KEY ("Manufacters_Id") REFERENCES "Manufacters"("Id");
ALTER TABLE "CarName" ADD CONSTRAINT "CarName_fk1" FOREIGN KEY ("Models_Id") REFERENCES "Models"("Id");


ALTER TABLE "Tires" ADD CONSTRAINT "Tires_fk0" FOREIGN KEY ("TiresSeason_Id") REFERENCES "TiresSeason"("Id");


ALTER TABLE "Garage" ADD CONSTRAINT "Garage_fk0" FOREIGN KEY ("Car_Id") REFERENCES "Car"("Id");

ALTER TABLE "Assistance" ADD CONSTRAINT "Assistance_fk0" FOREIGN KEY ("Garage_Id") REFERENCES "Garage"("Id");

