Validation
===========

- Prsim / CompositeWPF - http://msdn.microsoft.com/en-us/library/gg405484%28v=PandP.40%29.aspx
- IDataerrorInfo INotifyDataErrorInfo instead of throwing exceptions

- http://karlshifflett.wordpress.com/mvvm/input-validation-ui-exceptions-model-validation-errors/
- http://blogs.msdn.com/b/wpfsdk/archive/2007/10/02/data-validation-in-3-5.aspx

- Splitting Domain + Metadata
	- http://stackoverflow.com/questions/7820588/data-annotation-and-wpf-validation
	- http://stackoverflow.com/questions/8745325/wpf-textbox-maxlength-is-there-any-way-to-bind-this-to-the-data-validation-ma
	- http://wpf-4-0.blogspot.co.uk/2012/12/data-annotations-in-wpf-c.html
	- ValidationContext 
	- http://www.codeproject.com/Articles/39198/Automatically-validating-business-entities-in-WPF :)
	- http://www.codeproject.com/Articles/97564/Attributes-based-Validation-in-a-WPF-MVVM-Applicat

http://fluentvalidation.codeplex.com/

Testing 
=======

- DI is required
- ViewModels easy to test, providing we are not coupled to our view
- UI Testing - [White](https://github.com/TestStack/White)
- BDD - SpecFlow


WCF
===

Client per request - Ninject Factory
http://stackoverflow.com/questions/573872/what-is-the-best-workaround-for-the-wcf-client-using-block-issue

Authentication
==============

- Doesn't seem to use same mechanism as ASP.NET MVC4
- http://blog.magnusmontin.net/2013/03/24/custom-authorization-in-wpf/


Storing Data
============

User App Data Path to store temporary data, per user/application

```
	// Note, if(!Directory.Exists(...)) Directory.CreateDirectory(...) create if doesn't exist first.
	Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
```