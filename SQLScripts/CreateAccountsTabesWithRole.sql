CREATE TABLE public."Account"
(
	"UserId" SERIAL PRIMARY KEY,
	"UserName" VARCHAR(50) UNIQUE NOT NULL,
	"Password" VARCHAR(50) NOT NULL,
	"EMAIL" VARCHAR(100) UNIQUE NOT NULL,
	"CreatedDATE" TIMESTAMP NOT NULL,
	"LastLogin" TIMESTAMP	
);

CREATE TABLE public."Role"
(
	RoleId SERIAL PRIMARY KEY,
	RoleName VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Account_Role
(
  UserId integer NOT NULL,
  RoleId integer NOT NULL,
  grantDate timestamp without time zone,
  PRIMARY KEY (UserId, RoleId),
  CONSTRAINT account_role_role_id_fkey FOREIGN KEY (roleid)
      REFERENCES public."Role" (roleid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT account_role_user_id_fkey FOREIGN KEY (UserId)
      REFERENCES public."Account" ("UserId") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);