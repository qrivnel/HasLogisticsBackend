create table Clients (
	id serial primary key,
	companyname varchar(50) not null,
	billtitle varchar(150) not null,
	billaddress varchar(150) not null,
	telno varchar(13) not null,
	email varchar(25) not null
);

create table Staffs (
	id serial primary key,
	name varchar(25) not null,
	surname varchar(20) not null,
	sex char not null,
	age int not null,
	salary money not null,
	enterdate date not null,
	exitdate date,
	department varchar(20) not null,
	suitability bool not null
);

create table Stuffs (
	id serial primary key,
	name varchar(50) not null,
	metarialcode varchar(9) not null
);

create table Trailers (
	id serial primary key,
	laststuffkind varchar(10) not null,
	plate varchar(12) not null,
	isclean bool not null,
	type varchar(10) not null,
	lastinspectiondate date not null,
	suitability bool not null
);

create table Trucks (
	id serial primary key,
	staffid int unique,
	foreign key (staffid) references Staffs(id),
	plate varchar(12) not null,
	lastinspectiondate date not null,
	suitability bool not null
);

create table Orders (
	id serial primary key,
	truckid int,
	trailerid int,
	staffid int,
	stuffid int,
	clientid int,
	foreign key (truckid) references Trucks(id),
	foreign key (staffid) references Trucks(staffid),
	foreign key (stuffid) references Stuffs(id),
	foreign key (clientid) references Clients(id),
	foreign key (trailerid) references Trailers(id),
	distance int not null,
	loaddate date not null,
	deliverydate date not null,
	transportcost money not null,
	transportrevenue money not null
);

insert into Clients (companyname, billtitle, billaddress, telno, email)
values
('MARSA', 'MARSA YAĞ SAN. VE TİC. AŞ.', 'Ramazanoğlu mah. Mahmut Bayram cd. No:9 Pendik/İstanbul', '0216 570 1600', 'marsa@gmail.com'),
('ÜLKER BİSKÜVİ', 'Ülker Bisküvi Sanayi A.Ş.', 'Ereğli OSB Pk 41 Karaman', '0338 224 1339', 'ulker@gmail.com');

insert into Staffs (name, surname, sex, age, salary, enterdate, exitdate, department, suitability)
values
('Erhan', 'Karataş', 'M', 22, 25000, '2020-08-01', null, 'Şoför', true),
('Bertan', 'Barak', 'M', 21, 30000, '2015-01-01', null, 'Şoför', true),
('Özkan', 'Cırıtcı', 'M', 24, 27000, '2014-05-08', null, 'Muhasebe', true),
('Ece', 'İrvem', 'F', 22, 35000, '2020-08-01', null, 'Doktor', true);

insert into Stuffs (metarialcode, name)
values
('T0509000', '(B 02) - BESLER B YAĞI'),
('T0509002', 'BES BİS'),
('T0509007', 'BES 24 S'),
('T0509008', 'BESLER FK'),
('T0509904', 'BES IC 12 TANKER'),
('T0602128', 'AKBİS A-15 L BULK'),
('T0602130', 'AKBİS A-24 S BULK'),
('T0602132 ', 'AKBİS ÖZEL BULK'),
('T0602135', 'AKRİM BULK'),
('T0602142', 'MARS 41 BULK'),
('T0602143', 'MARS 42 BULK'),
('T0602144', 'MARS 42 N BULK'),
('T0602145', 'MARS 42B TANKER'),
('T0602149', 'AKRİM DOLGU KREMA BULK'),
('T0602151', 'AKRİM DOLGU KREMA SOFT BULK'),
('T0602161', 'AKBİS A-16 PS BULK'),
('T0602208', 'AKBİS KANOLA (BULK)'),
('T0602302', 'AKRİM Y BULK'),
('T0609106', 'BPS KT YAĞI'),
('T0609107', 'BPS KN YAĞI'),
('T0609200', 'BPS B YAĞI'),
('T0609907', 'BESLER NL TF (TANKER) İÇ PİYASA'),
('T0615301', 'BESLER NG BİSKOT TANKER'),
('T0661459', 'AKBİS K-24 BULK'),
('T0669100', 'BESLER BİSKOT KEK TANKER'),
('T0674105', 'BES 30 TANKER'),
('T0602127 ', 'AKBİS A-15 P BULK '),
('T0679004', 'AKBİS K-24 T BULK'),
('T0679003 ', 'AKRİM 22 BULK'),
('T0509204', 'BES 41'),
('T0609204', 'BES SKY ‘);

insert into Trailers (laststuffkind, plate, isclean, type, lastinspectiondate, suitability)
values
('Yağ', '16KV684', false, 'T1', '2024-10-06', true);

insert into Trucks (staffid, plate, lastinspectiondate, suitability)
values
(2, '01 ACF 766', '2024-10-10', true),
(3, '01 AHY 874', '2024-08-10', true),
(1, '01 ARM 767', '2024-07-10', true);

insert into Orders (truckid, staffid, stuffid, distance, loaddate, deliverydate, transportcost, transportrevenue)
values
(1, 2, 1, 300, '2024-01-12', '2024-01-13', 9030, 21000);