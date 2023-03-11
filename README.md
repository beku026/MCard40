<h1 align="center">Hi there, We are Beksultan, Chynara and Cholponai
<img src="https://github.com/blackcater/blackcater/raw/main/images/Hi.gif" height="32"/></h1>
<h1 align="center">MCard40</h1>
<h3>A Readme file typically consists of the following sections:</h3><br>

1.Project purpose/goal<br>
2.Users<br>
3.Technology stack<br>
4.Guidelines for writing variables<br>
5.Instructions on how to run the project<br>
<h2>Project objective</h2>
<p>There is often a need to urgently go to the hospital (polyclinic), but they do not accept without a medical card, and even if the doctor accepts the patient, he will write out instructions for treatment and medications on an ordinary piece of paper, which in turn is easy to lose. Or consider the case of honey loss. Cards, the entire medical history will be lost without the possibility of recovery, and you have to fill out and buy a new one (there have been cases when a person accumulated 10 cards). Also, with the next trip to the doctor, he had a different work schedule, and had to postpone the trip for days, weeks, or even abandon it altogether. That's why we decided to develop a website called "MedCard".
<br>Our website will allow: <br>
Patients to see their med. A map from anywhere in the world, to see the author of the record, prescribed medications, the last trip to the doctor by the date of the last record, to see a brief biography of the doctor and his schedule of work "reception time", electronic certificates for study / work and various courses / sections, as well as the readability of the printed text is much superior to human handwriting.
The doctor will be able to quickly and conveniently find information about the patient, prescribe everything necessary for him and view the previously left records of other doctors. See an assessment of the severity of a particular record, and take into account allergies and other important things when prescribing medications and treatment methods.</p>
<h2>Lecture hall</h2>
<p>People of all ages with minimal PC usage and internet availability.</p>
<h2>Technology stack</h2>
<ul type="square">
    <li>.NET - is a platform from Microsoft that allows you to create software applications;</li>
    <li>SQL Server - is a relational database management system. The main query language used is Transact—SQL;</li>
    <li>Logger - is a unix utility that provides a command interface for the syslog system log module;</li>
    <li>EF Core - used as an object-relational mapping module (O/RM), which:<ul><li>Allows developers .NET work with the database using .NET objects.</li><li>Eliminates the need for most of the data access code that usually has to be written</li></ul></li>
    <li>C# - is a modern object-oriented and type-safe programming language. C# allows developers to create different types of secure and reliable applications running in .NET.</li>
    <li>OOP is an approach in which a program is considered as a set of objects interacting with each other.</li>
    <li>SOLID - five principles of object-oriented programming that define the architecture of the program.</li>
</ul>

![struct](https://user-images.githubusercontent.com/31799470/189880565-38ff27a4-fbb2-4e4c-8d8b-b5c108c29a05.png)
<h1>Solution Structure</h1>
<h2>Conventions</h2>
<ul type="square">
    <li>All RequestDto should be named with prefix RequestDto: <code>TransferRequestDto</code></li>
    <li>All Commands should be named with prefix Command: <code>WithdrawCommand</code></li>
    <li>All Queries should be named with prefix Query:<code>GetUserAccountQuery</code></li>
    <li>All Response from Commands and Queries should be named with prefix OutDto: <code>GetUserAccountOutDto </code></li>
    <li>All folders should be created using plural form.</li>
</ul>

 ```diff
- Correct: Extension
+ Incorrect: Extension
```
<h2>How can I run the project ?</h2>
1.Clone the project. <br>
2.The project has 3 users: Admin, Doctor, Patient.  <br>
3.Admin creates a doctor (registers them).  <br>
4.Patient creates themselves (registers).  <br>
5.To start, create an admin. You need to navigate to the following path: MCard40.Web - Areas - Identity - Pages - Account - Register.cshtml.cs   <br>
6.Uncomment line 139.  <br>
7.Comment out lines 141 to 148.  <br>
8.Then run the project.  <br>
9.Go to the registration page.  <br>
10.Register the admin.  <br>
11.You are now logged in as the admin.  <br>
12.You need to close the tab (red cross).  <br>
Uncomment lines 141 to 148.  <br>
Comment out line 139.  <br>
Run the project.  <br>
Log in as the admin. 
In the sidebar, click "Create Doctor."  <br>
Create the doctor.  <br>
Log out of the admin.  <br>
Log in as the doctor.  <br>
Use other functions.  <br>
If you want to create a patient, simply log out of the admin/doctor role and click on the registration button. Register as a patient.
