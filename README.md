<h1 align="center">CAR RENTAL SYSTEM</h1>
<h2 align="center">Recap Project for Software Developer Training Camp on Kodlama.io</h2>

<p align="center">
    <img src="https://github.com/mcaliskan7/CSharpCamp/blob/main/images/kodlamaio_logo.jpg" alt="C# Camp on Kodlama.io">
</p>

Repository including Frontend Codes: https://github.com/mcaliskan7/ReCapProjectFrontend

### 💬OVERVIEW

It is a project that I continue to develop by applying what I have learned during the Software Developer Training Camp where I participated on Kodlama.io. It includes both **backend (C#)** and **frontend (Angular)** development. It supports **layered-architecture** including Entities, Data Access, Business and Core layers, also Console UI and Web API layers for testing.

The basic information required in a car rental system, brand, color, car images, rental information, individual and corporate user information is kept in its database. It performs **CRUD operations (Create - Read - Update - Delete)** and all other operations in conjunction with the database. While performing all these, it adapts to **Clean Code** and **DRY (Don't Repeat Yourself)** concepts thanks to its well-designed interfaces and classes.

**Autofac** is used as an **IoC (Inversion of Control) container**, which is a software design principle that enables the management of the life cycle of the objects in the project. In this way, dependency is tried to be minimized.

With the support of **FluentValidation**, the suitability status of the objects is evaluated before they are directed to business rules. In this way, without the need to make changes on dozens of lines of code, new special rules can easily be introduced for user mail and password, car information and pictures.

Another important structure applied to the project to write better and clearer codes is **AOP (Aspect Oriented Programming)**. Thanks to this method, it is ensured that the codes applied in many parts of the system, in other words **'Cross Cutting Corcerns'**, are abstracted and encapsulated.

**JWT (Jason Web Token)** integration is used to manage access to the database. It is ensured that the user logs in to the site so that they can access basic data. For data and transactions that users should not have access to, **authorization** is also made with JWT. With the **role management** used in the project, it is decided which operations will be accessible for certain users. For example, while a user can only get information from the database, an editor can be given the authority to edit this data and admin can have the authority to perform all kinds of operations.

All operations performed in this project were tested with **Windows Console App** beforehand, and after the backend development was completed to a great extent, it was tested with **Postman**. All the integrations mentioned in the content are working successfully. While the backend codes continue to be developed simultaneously, the start has been made to include the frontend development in the project.

Frontend Repository: https://github.com/mcaliskan7/ReCapProjectFrontend

### 🚀INSTALLATION
```bash
# Clone to repository
$ git clone https://github.com/mcaliskan7/CSharpCampReCapProject.git

# Go to the folder you cloned
$ cd CSharpCampReCapProject

# Install dependencies
$ dotnet restore
```
### 📚LAYERS

<p>
<details>
<summary>Business</summary><br/>

- [Business](/Business)
    - [Abstract](/Business/Abstract)
      - [IAuthService.cs](/Business/Abstract/IAuthService.cs)
      - [IBrandService.cs](/Business/Abstract/IBrandService.cs)
      - [ICarImageService.cs](/Business/Abstract/ICarImageService.cs)
      - [ICarService.cs](/Business/Abstract/ICarService.cs)
      - [IColorService.cs](/Business/Abstract/IColorService.cs)
      - [ICustomerService.cs](/Business/Abstract/ICustomerService.cs)
      - [IEntityService.cs](/Business/Abstract/IEntityService.cs)
      - [IRentalService.cs](/Business/Abstract/IRentalService.cs)
      - [IUserService.cs](/Business/Abstract/IUserService.cs)
    - [BusinessAspects](/Business/BusinessAspects)
      - [Autofac](/Business/BusinessAspects/Autofac)
        - [SecuredOperation.cs](/Business/BusinessAspects/Autofac/SecuredOperation.cs)
    - [Concrete](/Business/Concrete)
      - [AuthManager.cs](/Business/Concrete/AuthManager.cs)
      - [BrandManager.cs](/Business/Concrete/BrandManager.cs)
      - [CarImageManager.cs](/Business/Concrete/CarImageManager.cs)
      - [CarManager.cs](/Business/Concrete/CarManager.cs)
      - [ColorManager.cs](/Business/Concrete/ColorManager.cs)
      - [CustomerManager.cs](/Business/Concrete/CustomerManager.cs)
      - [RentalManager.cs](/Business/Concrete/RentalManager.cs)
      - [UserManager.cs](/Business/Concrete/UserManager.cs)
    - [Constants](/Business/Constants)
      - [Messages.cs](/Business/Constants/Messages.cs)
    - [DependencyResolvers](/Business/DependencyResolvers)
      - [Autofac](/Business/DependencyResolvers/Autofac)
        - [AutofacBusinessModule.cs](/Business/DependencyResolvers/Autofac/AutofacBusinessModule.cs)
    - [ValidationRules](/Business/ValidationRules)
      - [FluentValidation](/Business/ValidationRules/)
        - [BrandValidator.cs](/Business/ValidationRules/BrandValidator.cs)
        - [CarImageValidator.cs](/Business/ValidationRules/CarImageValidator.cs)
        - [CarValidator.cs](/Business/ValidationRules/CarValidator.cs)
        - [ColorValidator.cs](/Business/ValidationRules/ColorValidator.cs)
        - [CustomerValidator.cs](/Business/ValidationRules/CustomerValidator.cs)
        - [RentalValidator.cs](/Business/ValidationRules/RentalValidator.cs)
        - [UserValidator.cs](/Business/ValidationRules/UserValidator.cs)
</details>

<details>
<summary>ConsoleUI</summary><br>

- [ConsoleUI](/ConsoleUI)
    - [Program.cs](/ConsoleUI/Program.cs)
</details>

<details>
<summary>Core</summary><br>

- [Core](/Core)
    - [Aspects](/Core/Aspects)
      - [Autofac](/Core/Aspects/Autofac)
        - [Caching](/Core/Aspects/Autofac/Caching)
          - [CacheAspect.cs](/Core/Aspects/Autofac/Caching/CacheAspect.cs)
          - [CacheRemoveAspect.cs](/Core/Aspects/Autofac/Caching/CacheRemoveAspect.cs)
        - [Performance](/Core/Aspects/Autofac/Performance)
          - [PerformanceAspect.cs](/Core/Aspects/Autofac/Performance/PerformanceAspect.cs)
        - [Transaction](/Core/Aspects/Autofac/Transaction)
          - [TransactionScopeAspect.cs](/Core/Aspects/Autofac/Transaction/TransactionScopeAspect.cs)
        - [Validation](/Core/Aspects/Autofac/Validation)
          - [ValidationAspect.cs](/Core/Aspects/Autofac/Validation/ValidationAspect.cs)
    - [CrossCuttingConcerns](/Core/CrossCuttingConcerns)
      - [Caching](/Core/CrossCuttingConcerns/Caching)
        - [Microsoft](/Core/CrossCuttingConcerns/Caching/Microsoft)
          - [MemoryCacheManager.cs](/Core/CrossCuttingConcerns/Caching/Microsoft/MemoryCacheManager.cs)
        - [ICacheManager.cs](/Core/CrossCuttingConcerns/Caching/ICacheManager.cs)
      - [Validation](/Core/CrossCuttingConcerns/Validation)
        - [ValidationTool.cs](/Core/CrossCuttingConcerns/Validation/ValidationTool.cs)
    - [DataAcess](/Core/DataAccess)
      - [EntityFramework](/Core/DataAccess/EntityFramework)
        - [EfEntityRepositoryBase.cs](/Core/DataAccess/EntityFramework/EfEntityRepositoryBase.cs)
      - [IEntityRepository.cs](/Core/DataAccess/IEntityRepository.cs)
    - [DependencyResolvers](/Core/DependencyResolvers)
      - [CoreModule.cs](/Core/DependencyResolvers/CoreModule.cs)
    - [Entities](/Core/Entities)
      - [Abstract](/Core/Entities/Abstract)
        - [IDto.cs](/Core/Entities/Abstract/IDto.cs)
        - [IEntity.cs](/Core/Entities/Abstract/IEntity.cs)
      - [Concrete](/Core/Entities/Concrete)
        - [OperationClaim.cs](/Core/Entities/Concrete/OperationClaim.cs)
        - [User.cs](/Core/Entities/Concrete/User.cs)
        - [UserOperationClaim.cs](/Core/Entities/Concrete/UserOperationClaim.cs)
    - [Extensions](/Core/Extensions)
      - [ClaimExtensions.cs](/Core/Extensions/ClaimExtensions.cs)
      - [ClaimsPrincipalExtensions.cs](/Core/Extensions/ClaimsPrincipalExtensions.cs)
      - [ServiceCollectionExtensions.cs](/Core/Extensions/ServiceCollectionExtensions.cs)
    - [Utilities](/Core/Utilities)
      - [Business](/Core/Utilities/Business)
        - [BusinessRules.cs]()
      - [FileHelper](/Core/Utilities/FileHelper)
        - [FileHelper.cs]()
      - [Interceptors](/Core/Utilities/Interceptors)
        - [AspectInterceptorSelector.cs]()
        - [MethodInterception.cs]()
        - [MethodInterceptionBaseAttribute.cs]()
      - [IoC](/Core/Utilities/IoC)
        - [ICoreModule.cs]()
        - [ServiceTool.cs]()
      - [Results](/Core/Utilities/Results)
        - [Abstract](/Core/Utilities/Results/Abstract)
          - [IDataResult.cs](/Core/Utilities/Results/Abstract/IDataResult.cs)
          - [IResult.cs](/Core/Utilities/Results/Abstract/IResult.cs)
        - [Concrete](/Core/Utilities/Results/Concrete)
          - [DataResult.cs](/Core/Utilities/Results/Concrete/DataResult.cs)
          - [ErrorDataResult.cs](/Core/Utilities/Results/Concrete/ErrorDataResult.cs)
          - [ErrorResult.cs](/Core/Utilities/Results/Concrete/ErrorResult.cs)
          - [Result.cs](/Core/Utilities/Results/Concrete/Result.cs)
          - [SuccessDataResult.cs](/Core/Utilities/Results/Concrete/SuccessDataResult.cs)
          - [SuccessResult.cs](/Core/Utilities/Results/Concrete/SuccessResult.cs)
      - [Security](/Core/Utilities/Security)
        - [Encryption](/Core/Utilities/Security/Encryption)
          - [SecurityKeyHelper.cs](/Core/Utilities/Security/Encryption/SecurityKeyHelper.cs)
          - [SigningCredentialshelper.cs](/Core/Utilities/Security/Encryption/SigningCredentialshelper.cs)
        - [Hashing](/Core/Utilities/Security/Hashing)
          - [HashingHelper.cs](/Core/Utilities/Security/Hashing/HashingHelper.cs)
        - [JWT](/Core/Utilities/Security/JWT)
          - [AccessToken.cs](/Core/Utilities/Security/JWT/AccessToken.cs)
          - [ITokenHelper.cs](/Core/Utilities/Security/JWT/ITokenHelper.cs)
          - [JwtHelper.cs](/Core/Utilities/Security/JWT/JwtHelper.cs)
          - [TokenOptions.cs](/Core/Utilities/Security/JWT/TokenOptions.cs)
</details>

<details>
<summary>DataAccess</summary><br>

- [DataAccess](/DataAccess)
    - [Abstract](/DataAccess/Abstract)
      - [IBrandDal.cs](/DataAccess/Abstract/IBrandDal.cs)
      - [ICarDal.cs](/DataAccess/Abstract/ICarDal.cs)
      - [ICarImageDal.cs](/DataAccess/Abstract/ICarImageDal.cs)
      - [IColorDal.cs](/DataAccess/Abstract/IColorDal.cs)
      - [ICustomerDal.cs](/DataAccess/Abstract/ICustomerDal.cs)
      - [IRentalDal.cs](/DataAccess/Abstract/IRentalDal.cs)
      - [IUserDal.cs](/DataAccess/Abstract/IUserDal.cs)
    - [Concrete](/DataAccess/Concrete)
      - [EntityFramework](/DataAccess/Concrete/EntityFramework)
        - [CRSContext.cs](/DataAccess/Concrete/EntityFramework/CRSContext.cs)
        - [EfBrandDal.cs](/DataAccess/Concrete/EntityFramework/EfBrandDal.cs)
        - [EfCarDal.cs](/DataAccess/Concrete/EntityFramework/EfCarDal.cs)
        - [EfCarImageDal.cs](/DataAccess/Concrete/EntityFramework/EfCarImageDal.cs)
        - [EfColorDal.cs](/DataAccess/Concrete/EntityFramework/EfColorDal.cs)
        - [EfCustomerDal.cs](/DataAccess/Concrete/EntityFramework/EfCustomerDal.cs)
        - [EfRentalDal.cs](/DataAccess/Concrete/EntityFramework/EfRentalDal.cs)
        - [EfUserDal.cs](/DataAccess/Concrete/EntityFramework/EfUserDal.cs)
      - [InMemory](/DataAccess/Concrete/InMemory)
        - [InMemoryCarDal.cs](/DataAccess/Concrete/InMemory/InMemoryCarDal.cs)
</details>

<details>
<summary>Entities</summary><br>

- [Entities](/Entities)
    - [Concrete](/Entities/Concrete)
      - [Brand.cs](/Entities/Concrete/Brand.cs)
      - [Car.cs](/Entities/Concrete/Car.cs)
      - [CarImage.cs](/Entities/Concrete/CarImage.cs)
      - [Color.cs](/Entities/Concrete/Color.cs)
      - [Customer.cs](/Entities/Concrete/Customer.cs)
      - [Rental.cs](/Entities/Concrete/Rental.cs)
    - [DTO](/Entities/DTO)
      - [CarDetailDto.cs](/Entities/DTO/CarDetailDto.cs)
      - [CustomerDetailDto.cs](/Entities/DTO/CustomerDetailDto.cs)
      - [RentalDetailDto.cs](/Entities/DTO/RentalDetailDto.cs)
      - [UserForLoginDto.cs](/Entities/DTO/UserForLoginDto.cs)
      - [UserForRegisterDto.cs](/Entities/DTO/UserForRegisterDto.cs)
</details>

<details>
<summary>WebAPI</summary><br>

- [WebAPI](/WebAPI)
    - [Controllers](/WebAPI/Controllers)
      - [AuthController.cs](/WebAPI/Controllers/AuthController.cs)
      - [BrandsController.cs](/WebAPI/Controllers/BrandsController.cs)
      - [CarImagesController.cs](/WebAPI/Controllers/CarImagesController.cs)
      - [CarsController.cs](/WebAPI/Controllers/CarsController.cs)
      - [ColorsController.cs](/WebAPI/Controllers/ColorsController.cs)
      - [CustomersController.cs](/WebAPI/Controllers/CustomersController.cs)
      - [HeadPageController.cs](/WebAPI/Controllers/HeadPageController.cs)
      - [RentalsController.cs](/WebAPI/Controllers/RentalsController.cs)
      - [UsersController.cs](/WebAPI/Controllers/UsersController.cs)
    - [Properties](/WebAPI/Properties)
    - [Program.cs](/WebAPI/Program.cs)
    - [Startup.cs](/WebAPI/Startup.cs)
    - [appsettings.Development.json](/WebAPI/appsettings.Development.json)
    - [appsettings.json](/WebAPI/appsettings.json)
</details>
</p>

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE)

By Merve Çalışkan

LinkedIn: https://www.linkedin.com/in/mervecaliskan/
E-mail: **merve.caliskan@std.yeditepe.edu.tr**
