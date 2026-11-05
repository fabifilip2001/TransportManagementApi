-- ====================================
-- Drop Constraints
-- ====================================
alter table Models drop constraint if exists model_makeid_fkey;
alter table Vehicles drop constraint if exists vehicles_model_id_fkey;

-- ====================================
-- Drop Tables
-- ====================================
drop table if exists makes;
drop table if exists models;
drop table if exists vehicles;
-- ====================================
-- 1. Make Table
-- ====================================
create table Makes (
	Id INT generated always as identity primary key,
	Name VARCHAR(100) not null unique
);

-- ====================================
-- 2. Model Table
-- ====================================
create table Models (
	Id INT generated always as identity primary key,
	Name VARCHAR(100) not null unique,
	MakeId INT not null references Make(Id)
);

-- ====================================
-- 3. Vehicles Table
-- ====================================
create table Vehicles (
	Id INT generated always as identity primary key,
	Plate_Number VARCHAR(20) not null unique,
	Fabrication_Year DATE not null,
	Status INT not null default 1 check (Status < 5),
	Model_Id INT not null references Models(Id),
	Created_At TIMESTAMPTZ not null default now(),
	Updated_At TIMESTAMPTZ
);