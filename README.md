Ticket Management System
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

I used an ASP.NET Core MVC application to develop the solution. I mainly use front-end HTML, CSS, JavaScript, JQuery, and Bootstrap here. The backend uses ASP.NET, C#, and the data storage database is SQL Server Management Studio(SSMS). 

The ticket management system is configured with three controllers for the three modules —admin, agent, and customer and one controller for the index screen. I also made three repositories for customers, agents, and tickets that CURD will handle there.


Admin Portal
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
This is our Ticketing Portal dashboard's initial screen.
![Ticketingportal](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/f14b9a0c-0680-48a8-9d1a-ee32e0e1e8b6)

Admins can log in with their admin credentials; if these are not accurate, a login failure message is displayed. 
![AdminLoginFailed](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/7a47a1e4-511e-4dc5-8179-3d43a5cee608)

Sign in, assuming that credentials are accurate. He is limited to logging in with these credentials: Password: Admin@12; Username: admin@gmail.com
![AdminLogin](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/2ebd51b0-da3e-4dd5-ac0e-0e2d5898292b)

The dashboard of the admin portal is this.
![AdminPortal ](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/aa49f386-4e71-4d4a-93cd-4a1f93ede64a)

With enough information, the admin can create a new Agent. Generate a new AgentID automatically and send the details to the agent list
![Create a new agent by admin](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/52962c7d-a331-4d92-b4ad-07d62145803a)

Admin has a list view of every agent. Admin can Update and Delete an agent's details.
![AgentDetailsList in Admin](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/f95aa315-ad35-4d23-ad1a-42909cc73b41)

Admin can Update an agent's details.
![editAgentbyAdmin](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/5f6096f7-19e3-4a00-9e47-2969f841e552)



Agent Portal
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Agent can log in with their agent credentials; if these are not accurate, a login failure message is displayed. 
![agentloginfailed](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/f9e596d0-0acd-49cd-a7af-3a55b3437bce)

Sign in, assuming that credentials are accurate. He is limited to logging in with these credentials: Password: Agent@12; Username: agent@gmail.com
![AgentLogin](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/ec782d4d-4487-463b-af5f-43d187d537a6)

The dashboard of the agent portal is this.
![AgentPortal](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/813ebdcd-5a80-4844-9395-0e8b1054dbc8)

With enough information, the agent can create a new customer and tickets. 
![AgentNewTicket](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/1fc99194-00e9-4dd2-be5b-24a02d326911)
![AgentCustomerCreation](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/37d637b9-fb53-45d2-b8cc-1b71c041748d)

Generate a new customer id for creating new customer and ticket Id for creating new tickets automatically and send the details to the list
![AgentCustmordetails](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/22b08233-c1be-4801-9250-ffb1d3074d52)
![AgentTicketList](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/b5dfd882-bbce-4f78-91cc-1fb779781bcb)

An agent can use the ticket ID, customer ID, and description to search tickets.
![AgentTicketSearch](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/b0d8c33b-3c61-4fa9-9305-d069d32dc201)

Agents are able to assign tickets to other agents.
![Assign Ticket](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/72dbb5d2-f51b-4e61-9113-22ddef019d36)

Agent is able to modify the ticket's status.
![changeStatus](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/427ae432-0e14-44a7-aa59-6c98ca7176ed)

Agent can update the ticket and delete
![EditTicket](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/f722a73e-7dd6-4440-9c54-678d1a6ee288)


Customer Portal
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Customer can log in using their own credentials, just like in the database. else generate a login error
![CustLoginFailed](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/f69e4dab-b5c6-49a6-b042-a8ef2aca569d)
![Cust Login](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/10226082-8fee-481f-8c39-f174fe586e22)

The dashboard of the Customer portal is this.
![CustPortal](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/cca07f5a-c531-4235-949f-86aa73261aae)

With enough information, the customer can create a new tickets. 
![Cust new Ticket](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/2c6bb6a0-79b0-47e7-99e3-1258fadc2f05)

Generate a new ticket Id for creating new tickets automatically and send the details to the list
Track and manage tickets created by that customer.
![Ticket list](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/3cc4c3b8-2246-46d0-9bea-df530ce31d74)

Customer can update the ticket and delete
![Edit Ticket](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/76c0c3f3-c0a7-4a12-b3bd-22f35113f339)

The customer can view their own profile information.
![Profileview](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/decd3c05-fd01-4f7e-a8c2-4806fbcce101)


Database
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
I made three tables in the database: one with the admin credentials, another with the agent details, a third with the customer details, and a fourth with the ticket details. I use every CURD operation in stored procedures in this project.

Admin Table

![adminCreds](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/ee3d66bc-60e7-4999-aca9-93c0da171e31)

Ticket Table

![TicketTable](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/1e4db7f2-48fb-47cb-803b-9a9d9556fcc3)

Customer Table

![CustTable](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/53ef766e-ee70-4190-9152-b310f310e356)

Agent Table

![AgentCreds](https://github.com/akhilkurup194/Ticketing_Sysytem/assets/174370832/e9e9b6ae-fefb-49d1-ada0-9bd8c702b6b8)


