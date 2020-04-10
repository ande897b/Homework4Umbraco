Okay so i gave it a shot, not everything went as hoped but i did my best.


Go to package manager and do the following commands:
	Add-migration LoginFromUmbraco -Context ApplicatinDbContext
	Update-Database -Context ApplicatinDbContext


If its launches on local host without problems ->
Register in top right corner (Email + Password(Can just be made up), This was supposed to be admin rights) - You can enter the raffle without being logged in, but to view entries it is required.
Features and things i spend time on:
Seeding database with the Serial Numbers from the .txt
Loading Participants from database (And saving when new ones are made)
Only accepting Valid Serial number formats (xxxx-xxxx-xxxx-xxxx)(And checking that each serial number is used a maximum of 2 times)
Pagination with 10 participants on each page. (Obviously you need to create 10+ valid entries to see it)
Sorting on Pagination 



