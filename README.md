# HealthyMed

A healthy med web application for health services, prescriptions etc. appointments.  :calendar:

:dart:  My project for the ASP.NET Core course at SoftUni. (October 2022) 

## :information_source: How It Works

- Guest visitors: 
  - browse departments of health services;
  - view doctors in their speciality;
  - read comment posts.
- Logged Users:
  - book appointments using interactive datepicker; 
  - can cancel appointments; 
  - can write comments posts.  
- Doctor (user role):
  - confirms/declines user appointments; 
  - create/deletes user prescription.
  - can review his prescriptions history.
- Admin:
  - creates/deletes departments, users(delete only); 
  - assign/remove roles; 
  - can review the appointments history.

## :hammer_and_pick: Built With

- ASP.NET Core 6.0
- Entity Framework (EF) Core 6.0.10
- Microsoft SQL Server Express
- ASP.NET Identity System 6.0.10
- MVC Areas with Multiple Layouts
- Razor Pages, Sections, Partial Views
- View Components
- Repository Pattern
- Dependency Injection
- xUnit
- Moq
- Sorting, Filtering, and Paging with EF Core
- Data Validation, both Client-side and Server-side
- Data Validation in the Models and Input View Models
- Custom Validation Attributes
- Responsive Design
- CloudinaryDotNet
- Bootstrap
- jQuery

## :gear: Application Configurations

### 1. The Connection string 
is in `appsettings.json`. If you don't use SQLEXPRESS, you should replace `Server=.\\SQLEXPRESS;` with `Server=.;`

### 2. Database Migrations 
would be applied when you run the application, since the `ASPNETCORE-ENVIRONMENT` is set to `Development`. If you change it, you should apply the migrations yourself.

### 3. Seeding sample data
would happen once you run the application, including Test Accounts:
  - User: user@appuser.com / password: 123456
  - Doctor: doctor@doctor.com / password: 123456
  - Admin: admin@admin.com / password: 123456
 
### 4. Cloudinary Setup - optionally
#### Running without it:
You won't get an error for missing Cloudinary Credentials - it is handled by using predefined (already uploaded) image, when Cloudinary configuration is missing. So when you are creating content in admin panel, it will be added but not with the image you have chosen.
#### If you want to actually upload images, you should:
1. Add Cloudinary Credentials in `appsettings.json` in the format:
```json
  "Cloudinary": {
    "CloudName": "",
    "ApiKey": "",
    "ApiSecret": "",
    "EnvironmentVariable": ""
  }
```
2. Update the Cloudinary Setup part of `Program.cs`'s `ConfigureServices` method as follows:
```csharp
            // Cloudinary Setup
            Cloudinary cloudinary = new Cloudinary(new Account(
                this.configuration["Cloudinary:CloudName"],
                this.configuration["Cloudinary:ApiKey"],
                this.configuration["Cloudinary:ApiSecret"]));
            services.AddSingleton(cloudinary);
```

## :framed_picture: Screenshot - Home Page

![HealthyMed-HomePage](https://res.cloudinary.com/healthy-med/image/upload/v1697993568/uploads/HomePage_mfukrd.png)

## :framed_picture: Screenshot - Make An Appointment Page

![HealthyMed-MakeAnAppointment](https://res.cloudinary.com/healthy-med/image/upload/v1697993568/uploads/BookAppoinmentPage_kdbrwl.png)

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgments

#### Using [ASP.NET-MVC-Template](https://github.com/NikolayIT/ASP.NET-MVC-Template) developed by:
- [Nikolay Kostov](https://github.com/NikolayIT)
- [Stoyan Shopov](https://github.com/StoyanShopov)
- [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)