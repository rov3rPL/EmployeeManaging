Nowy agregat:

Entity
	+ Testy (Domena)
IEntityRepository, EntityRepository
	+ Testy (Infrastruktura)
	+ Rejestracja DI
EntityDbContext //IUnitOfWork
	+ Testy (Infrastruktura)
	+ Rejestracja DI
fabryka EntityDbContextFactory

Command, Handler
	+ Testy z mockami (Aplikacja)
	+ Rejestracja

