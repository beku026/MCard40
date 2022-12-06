<h1 align="center">Hi there, We are Nurdin and Cholponai
<img src="https://github.com/blackcater/blackcater/raw/main/images/Hi.gif" height="32"/></h1>
<h1 align="center">MCard40</h1>
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
