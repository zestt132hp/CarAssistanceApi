-- Database: postgres

-- DROP DATABASE postgres;

CREATE DATABASE CarAssistance
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Russian_Russia.1251'
    LC_CTYPE = 'Russian_Russia.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

COMMENT ON DATABASE CarAssistance
    IS 'This DataBase created by Anikeev Nikolay, also this DB must been add to source control';