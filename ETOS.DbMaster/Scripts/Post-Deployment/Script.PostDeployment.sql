/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r InitialData\Users.sql
:r InitialData\Roles.sql
:r InitialData\UserRoles.sql
:r InitialData\Brands.sql
:r InitialData\Models.sql
:r InitialData\Vehicles.sql
:r InitialData\TransportTypes.sql
:r InitialData\Statuses.sql
:r InitialData\Priorities.sql
:r InitialData\Locations.sql
:r InitialData\Orgstructures.sql
:r InitialData\Positions.sql
:r InitialData\Employees.sql
:r InitialData\Customers.sql
:r InitialData\Contractors.sql
:r InitialData\Requests.sql

