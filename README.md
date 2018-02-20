## Support MixERP Project

To keep enchancing and improving MixERP, Frapid, and several other open source projects that we've built, please consider a donation.


|Symbol|Coin|Address|
|--- |--- |--- |
|BTC|Bitcoin|1LJJDmFUvDw4yjf5jm5uwJQ4AgYbp5p8bj|
|ETH|Ethereum|0xc3cad0b41adb78760a5d53e381fe4b7390e630fc|
|ETC|Ethereum Classic|0xc3cad0b41adb78760a5d53e381fe4b7390e630fc|
|LTC|Litecoin|Le5kpLJ3XJDRZjGXiZNzBnB3F3RwwtHhzT|
|USDT|US Dollar Tether|1NcntiVJDCk1bLXDhkuaJtJ1MqTPU1hUvT|
|ZEC|ZCash|t1b7Qm6EByoDVFe3Abx2Qq7MPeey6aQZ5JU|
|DASH|Dash|XkWsQcSL5sPxkQxhNtoBTJ3ke4v6XameVh|
|ICX|Icon|0xc3cad0b41adb78760a5d53e381fe4b7390e630fc|
|EOS|EOS|0xc3cad0b41adb78760a5d53e381fe4b7390e630fc|
|OMG|OmniseGo|0xc3cad0b41adb78760a5d53e381fe4b7390e630fc|
|EOS|EOS|0xc3cad0b41adb78760a5d53e381fe4b7390e630fc|
|NEO|NEO|AScNj7vhZxBnJk7ycLMr3uYTnmQSLFmLxg|
|XVG|Verge|DT7WgdXboohvFDc7YMrJPmUWBfTcGWQWa5|

![MixERP Dashboard](https://raw.githubusercontent.com/mixerp/mixerp/master/screenshots/dashboard.png)

# Update September 29, 2017

- Follow the developer documentation in youtube. Please subscribe to our channel: [MixERP Youtube Channel](https://www.youtube.com/channel/UCS5Bt00s3_8-o0oI4CLDYDg).
- [List of v2 feature screenshot](features.md).

# Update July 12, 2017

Thank you for supporting MixERP v1. If you cannot find latest activities in this repository, don't worry. We're working on Frapid framework and individual v2 repositories (listed below) instead. 

# Update December 17, 2016

As planned, a dedicated CI instance of MixERP v2.0 (on SQL Server) has been deployed:

- http://ci.frapid.com (PostgreSQL Server)
- http://ci2.frapid.com (SQL Server)

# Update December 15, 2016

We have been porting MixERP v2 database to SQL Server for quite some time. Please wait for a week or two, while we quality test the script and update the SQL Server CI instance:

http://ci2.frapid.com/

All of the v2 repositories now support SQL Server.

# Update Novemver 26, 2016

Please follow this repository to setup a development instance of MixERP v2.0 in your computer.

https://github.com/mixerp/init

# Update November 15, 2016

## Release Date

We are pleased to annouce the first beta release of Frapid CMS and MixERP v2 on early January 2017. Please check the v2.0 repositories below.

# Update October 19, 2016
We do have some great news related to the new version of MixERP which is undergoing rapid development. On top of that, we've decided to open source the POS solution as well. MixERP v2 is the coolest kid in the town which has a lot of exciting new features along with CMS and POS.

MixERP will natively support SQL Server from v2.0 Beta 1 onward.

### How to Access MixERP v2 Demo?

MixERP v2 demo site is now a part of the build process. We've written build scripts so that the v2 version of demo site is updated as soon as there is new code change in one of our git repositories.

This page contains information on how you can access the new demo

https://mixerp.org/site/erp/demo

# Roadmap for the Next Version (v2.0)

Due to popular demand, MixERP 2.0 will also support SQL Server and SQL Azure and will be developed keeping
shared hosting environment in mind. Even though we almost do not depend on WebForms, we will rewrite the whole application in a new technology. In case you wonder if you should wait for v2.0 release, you are wrong. There is no release date for v2.0 right now. It will be ready when it will be ready.

But, we do have some plans:

* v2 will not be backward compatible with MixERP 1.x.
* v2 will have a lot of functional differences with v1. We will later update the roadmap.
* We will try to build a data migration utility.
* v2 will be based on [Frapid Framework](http://github.com/frapid/frapid).
* v2 will be on MVC, similar to other [Frapid Modules](http://github.com/frapid/frapid). No WebForms.
* v2 may (hopefully) run on vNext and *nix-based operating system. We are unsure about [vNext's release date](https://github.com/aspnet/Home/wiki/Roadmap/_compare/04ec44cc1f7039a5d1161cce0efa812d228b24bc) and how long other open source community (the ones we depend on) will take to support vNext.

Because [Frapid](http://github.com/frapid/frapid) is going to host MixERP modules, you should learn and build
modules for Frapid. Frapid, being a multi-tenant application development framework, enables
you to create modules that you can target for:

* Frontend (Website, Blog, Forums, Job Vacancies, Helpdesk, Customer Portal, or whatever you call it.)
* Backend (Management Console, Management Portal, Dashboard, User Area, or whatever you call it.)

The two main objectives of Frapid are:

1. To be able to host a **single Frapid application instance** on multiple servers. Multi tenancy, web farm, or whatever they say.
2. To be able to host unlimited tenants with or without SSL support on a **single IIS Site instance**. Opposite of the above.

**Use Case for #1**

You want to scale your *popular website* to multiple servers.

**Use Case for #2**

You want to create a new Frapid instance (with a bunch of your own modules and call it something else. Example: MixERP 2.0 is Frapid with some ERP modules.) for your customers with as minimum effort as possible. In simple words, you can host:

* foo.bar.com
* fiz.buzz.com
* fuzz.faux.com

by just pointing the DNS entries to your IIS Server. Frapid will automatically understand these domains and will create separate resources for each tenant, totally isolated from each other. By the way, Frapid also supports cookieless domains if you want to dedicate a domain name to serve static contents.

Enough about Frapid now, go and look for yourself.

## v2.0 Repositories

- [Frapid Core](https://github.com/frapid/frapid/)
- [HRM Module](https://github.com/mixerp/hrm/)
- [Finance Module](https://github.com/mixerp/finance) 
- [Inventory Module](https://github.com/mixerp/inventory)
- [Purchase Module](https://github.com/mixerp/purchases)
- [Sales Module](https://github.com/mixerp/sales)

Please note that the sales module has POS features.

# So, What Is MixERP?

MixERP is an awesome feature-rich and easy-to-use free ERP software for small business.

Designed from the ground up, MixERP Community Edition integrates most of the useful functionalities of an ERP solution with extra emphasis on simplification of the implementation.

MixERP has a guided implementation feature which makes it a piece of cake for you to properly setup your ERP instance.

### General ERP Features

* Centralized Architecture
* Access Policy Management
* Transaction Verification
* Automatic Verification
* End of Day Operations
* Document Manager
* Custom Fields
* Report Builder
* Guided First Steps


### Human Resource Management

* Attendance & Leave Management
* Employee Contracts
* Resignations, Leaves, and Exits
* Job Titles
* Employment Statuses
* Pay Grades
* Employee Experience
* Employee Qualifications
* Work Shifts


### Account Receivable / Sales / Selling
* Sales Quotation & Order
* Direct Sales
* Sales Delivery
* Sales Return
* Custom Receipts
* Sales Team & Salesperson Info
* Sales Commission
* Late Fee Fine
* Recurring Invoices

### Account Payable / Purchase / Buying / Procurement
* Purchase Order
* Direct Purchase
* Goods Receipt Note
* Purchase Return
* Purchase Reorder
* Purchase Reports


### Inventory / Stock
* Inventory Transfer
* Inventory Transfer Request
* Inventory Transfer Authorization
* Inventory Transfer Delivery
* Inventory Transfer Receipt
* Inventory Items
* Compound Inventory Items (Kits)
* Cost Price
* Selling Price
* Customer & Supplier
* Stores
* Counters
* Unit of Measure
* Compound Unit of Measure
* Shipping Companies


### Finance / Accounting
* Journal Entry
* Exchange Rate Update
* Voucher Verification
* End of Day Operations
* Chart of Accounts
* Currency Management
* Bank Accounts
* Ageing Slabs
* Cash Flow Headings
* Cash Flow Setup
* Cost Centers
* Payment Cards
* Merchant Fee Setup
* Trial Balance & PL Account
* Balance Sheet & Cash Flow


### Office / Back Office
* Tax Master
* Tax Authorities
* Sales Tax Types
* State Sales Taxes
* Counties Sales Taxes
* Sales Taxes
* Tax Exempt Types
* Sales Tax Exempts
* Sales Tax Exempt Setup
* Office & Branch Setup
* Fiscal Year Information
* Frequency & Fiscal Year Management
* Department Setup
* Role Management
* User Management
* Cash Repository Setup
* Entity Setup
* Industry Setup
* Country Setup
* State Setup
* County Setup
* Custom Fields
* Flag Management
* Voucher Verification Policy
* Automatic Verification Policy
* Menu Access Policy
* Store Policy
* Api Access Policy
* Default Entity Access Policy
* Entity Access Policy
* Database Statistics
* Backup Database
* Change User Password
* Check Updates
* Report Writer
* Opening Inventory
* Attachment Parameters
* Currencylayer Parameters
* Database Parameters
* SMTP Parameters
* MixERP Parameters
* OpenExchangeRates Parameters
* ScrudFactory Parameters
* Switches
* Other Setup
* Genders
* Identification Types
* Nationalities



#Where Is Documentation?
[MixERP Documentation Website](http://docs.mixerp.org)


##Why PostgreSQL Server?

MixERP 1.x is **PostgreSQL-only ERP** and **we will not support** any other DBMS anytime soon in the near future. However, we fully support compatible PostgreSQL forks such as [PostgreSQL Plus Advanced Server](http://www.enterprisedb.com/).

We have been receiving tons of queries on why PostgreSQL? We chose PostgreSQL Server because:

* PostgreSQL is platform independent.
* We have plans to support Apache and nginx.
* We have plans to support *nix based operating system.
* PostgreSQL is free no matter how big your data grows, unlimited processors, unlimited cores, unlimited memory. You will never be forced to upgrade to higher version due to a limitation of database size or similar.
* PostgreSQL is an [excellent choice for enterprise application](http://www.computerweekly.com/feature/Hot-skills-PostgreSQL).
* PostgreSQL does have [paid support plans](http://www.infoworld.com/article/2617783/open-source-software/the-stealth-success-of-postgresql.html) for enterprises.
* PostgreSQL is [ahead of commercial database](http://www.infoworld.com/article/2608863/nosql/postgresql-ramps-up-its-nosql-game.html) vendors in terms of development. Also see [this](https://wiki.postgresql.org/wiki/What%27s_new_in_PostgreSQL_9.0), [this](https://wiki.postgresql.org/wiki/What%27s_new_in_PostgreSQL_9.1), [this](https://wiki.postgresql.org/wiki/What%27s_new_in_PostgreSQL_9.2), [this](https://wiki.postgresql.org/wiki/What%27s_new_in_PostgreSQL_9.3), and [this](https://wiki.postgresql.org/wiki/What%27s_new_in_PostgreSQL_9.4). And [this](http://www.postgresql.org/docs/9.4/static/release-9-4-1.html) as well.
* We have been SQL Server developers long before we even knew PostgreSQL Server existed. We love SQL Server, but PostgreSQL is a better fit for, and brings added advantage to MixERP.


##You Don't Have to Bang Your Head to Learn or Implement MixERP

The first thing that we ever discussed when starting this project was simplicity. Designed from scratch, MixERP integrates most of the useful functionality of an average ERP solution with extra emphasis on simplification of its modules. Switching to MixERP from your previous ERP solution will not be a nightmare unlike in most cases with other ERP Solutions.

###MixERP Is a Pure
* multi-currency,
* multi-lingual, 
* and multi-establishment ERP Solution.

##MixERP Disallows Side Effecting Functionality

Unlike other ERP solutions, MixERP restricts some side effecting functionality. For example, modification of past dated transactions is not allowed. This ensures that you cannot have two different balance sheets of the same date because of the modifications made. 

##Related Topics
* [MixERP Documentation](http://docs.mixerp.org)
* [Developer Documentation](http://docs.mixerp.org/docs/developer/index.html)
* <a href="http://demo.mixerp.org" target="_blank">MixERP Demo Website</a>
* [Contribution Guidelines](http://docs.mixerp.org/docs/contribution-guidelines.html)
* <a href="http://mixerp.org/" target="_blank">Project Website</a>
* <a href="https://www.facebook.com/mixerp.official/" target="_blank">Follow MixERP on Facebook</a>
* <a href="http://www.facebook.com/groups/183076085203506/" target="_blank">Facebook Discussions Group</a>
* <a href="http://mixerp.org/forum/" target="_blank">Community Forum</a>
* [Project Milestone](https://github.com/mixerp/mixerp/milestones)

##List of Supported Languages

* English (MixERP Global Developers)
* Deutsch ([Johann Schwarz, Austria](https://github.com/Johann-Schwarz))
* español ([Jonathan Valle, Nicaragua](https://github.com/JonathanValle))
* français ([Nubiancc, Egypt](https://github.com/nubiancc))
* Bahasa Indonesia
* 日本語
* Bahasa Melayu
* Nederlands
* português
* русский
* svenska
* 中文
*  العربية ([Nubiancc, Egypt](https://github.com/nubiancc))

##How Can I Support MixERP?

* [Translate MixERP in your language](http://docs.mixerp.org/docs/developer/translate-mixerp.html).
* Build and host MixERP on your development server.
* Join us by following this project.
* Report bugs and/or issues on github.
* Tell your friends about MixERP.
