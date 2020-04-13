Every creation has been added onto a HTTPGET-request, so testing can be done through a browser.
In the following list of paths, the base-path ("localhost:<port>/api/[controller]/") should be added behind the path, to perform the way we designed it.

NOTE: Almost all ID's can be found under "api/Student"-path. The rest (Assignment-ID) can be found under "api/Assignment".

How To Start:
* Change Connectionstring in DAB_Assignment2-project.
* Database-Update
* F5

URL-Paths:

[controller]: Exercise
CreateExercise:		Create/{Lecture}/{Number}/{Where}/{open}/{TeacherID}/{studentID}/{CourseID}
ChangeLocation:		Update/{Lecture}/{Number}/{Where}
ChangeTeacher: 		Update/{Lecture}/{Number}/{TeacherID}
ChangeStudent:		Update/{Lecture}/{Number}/{StudentID}
ChangeCourse:		Update/{Lecture}/{Number}/{CourseID}

[controller]: Teacher
CreateTeacher: 		Create/{TeacherName}/{TeacherID}/{CourseID}

[controller]: Course
Get:			"Default-Path. Nothing extra should be added."
CreateCourse:		Create/{courseName}
Help-Request Stats:	Stats/{CourseID}
AddStudent:		AddStudent/{studentID}/{courseID}/{active}/{semester}


[controller]: Assignment
CreateAssignment:	Create/{CourseID}/{TeacherID}
AddStudent:		AddStudent/{AssignmentID}/{studentID}


[controller]: Student
GetAllOpenHelpRequests:	"Default-Path. Nothing extra shoud be added."
CreateStudent:		Create/{studentName}/{studentID}
GetHelpRequestsFromId:	{id}
AddCourse:		AddToCourse/{studentID}/{courseID}/{active}/{semester}

