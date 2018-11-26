Project available in:
https://github.com/Giovanni-Russo-Boscoli/todoapi (please use master branch)

Todo Task Project built using Asp.Net Core framework 2.1 using MVC model programming.

The solution was successfuly tested using the following browsers:
- Chrome (70.0.3)
- Firefox (63.0.3)
- Opera (56.0.3)
- Safari (5.1.7)
- Edge (Microsoft Edge 41.16299.402.0)
- IE 11 (11.431)

NOTE*: The funcionality 'Refresh' used to reload data in 'datables' grid with  doesn't work in IE 11.

Patterns:
- Singles Responsability (classes)
- Dependency Injection (make the code more testable)
- Repository (make the code more testable, dettached business logic and DB persistence)

Test:
- Was created Unit Tests (Todo.Api.Service.Test) using XUnit and Moq.
- Moq was used to make a fake 'Repository'

NOTE*: Integration test was not possible to create in Repository Project due short time

JS Libraries:
- Jquery
- Bootstrap
- Datatables (create grids/tables)
- Toastr (Notification)
- Json

Razor:
- I decided to use Razor because in this situation (small project) is more viable (make easier to create HTML using model and changes during development), but in case the project be bigger I no think could be a good option to mix and chunk Html tag with source code and avoid any business logic in HTML files.

NOTE*: I started building the solution using a login and dynamic menu models developed by myself in the past but was necessary few changes and adaptations because I was using old framework (4.5 Standard) and some functionalities as bundleconfig file, @helper and @Html.Action() (Html helper) are created in a different way using asp.net core.

Menu:
 - The Menu is dynamic and render it in execution time. It can be used accessing data base but in this case is in a class (Todo.Api.Model.Navbar.cs). If you want test Menu just change the status properties of the created objects in(Todo.Api.Model.Navbar.cs) for 'true'. (Consider that each object identify itself as parent or child. If you change a status propertie of a child item, make sure that their parent item is true as well).


Using solution:

Were created 2 differents users:

User: test
Password: pwd123

User: Giovanni
Password: pwd456

If you log in using 'test' user nothing will be shown because there's no data/file created for this user;
If you log in using 'Giovanni' user a json file was already created and some data will be shown in task list;

NOTE*: If you want to add a new user, go to 'Todo.Api.Repository.Concrete.LoginRepository'

Were used json files to reproduce the concept "In-memory". Instead of tables in DB, a json file is created to save your records (one file for each user). I decided to create one file per user considering perfomance to access information inside the file, each transaction (create a new task, edit or delete) must rewrite the whole file;
NOTE*: I know the existence of EF in-memory but I never used it before and I'm not sure if it would be possible to see the same information by user after logout and login again as asked;

If you delete the last record of task the file is deleted as well;

If you are managing the file manually, remember that is a simulation of DB and it's not a relational information (be careful with Id tasks);

Tasks you can do:

- Log in:
	- Fill up User and Password fields;

- Add a new task:
	- Hit the "plus" button in the header of grid. A modal will open and you can insert a description (free text. You can add a html tags. In case that html tags are not accepted I would create a filter using regex to avoid those tags);

- Edit a task:
	- Hit the 'pencil' button in the line that you want edit (A confirm box will appear). The same modal will open with the description and you can edit the text;
	NOTE*: This button is disabled for the tasks marked as done;

- Delete a task:
	- Hit the 'trash' button to delete any task (A confirm box will appear);
	NOTE*: When you delete the last task the json file will be deleted as well;

- Check/Uncheck task as done:
	- Hit the checkbox in the line that you want mark as check/done (A confirm box will appear). The background-color of this line will switched to green;
	If you hit the checkbox again (A confirm box will appear) the task will be marked as unchecked/undone and the background-color will be grey again(alternative row style class for grids);
	NOTE*: A css class used by datatables.js called "sorting_x" doesn't accept a change background-color, so the column selected to sort won't change;

- Ordering by:
	- Creation Date;
	- Modification Date;
	- Description;

- Search by any text shown in the grid:
	- Search by free text in the field 'Search' (top-right of the grid/table header);

- Pagination: 
	- Will be available from 10 records;

- Logout:
	- Hit the 'User' icon in the right side of menu and hit the 'power off' icon;


- What would I like to do if I had more time:
	- Delete all tasks:
		Funcionality to delete all tasks whit just one click;
	- Create List of task:	
		Each task would be a list with N tasks inside and you could named it;
	- Pagination by 'Done column':
		Enable pagination through column 'Done';
	- Fix 'sorting_X' css class:
		Change column color even for the sorted column;
	- Integration Tests:
		Create a integration tests in Repository project;
