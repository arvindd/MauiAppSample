# Introduction
This repository contains a starting point for all your MAUI applications. 

The best way to use this is to open the solution in your visual studio, and export the project MauiAppSample as a "Visual Studio Template" (Project -> Export Template) after selecting the project.

# What does this sample do?
Well, the sample application is really very simple - it just shows up a button, which when clicked, throws up some numbers on a ListView that is just above the button. Everytime the button is clicked, some numbers are added to this ListView.

This button is simply labelled "Track Location" and the numbers that show up on the ListView are the latitude and longitude values of a location.

# Architecture of the sample
The sample has a simple MVVM architecture as shown below. All the Views are coded in GREEN, ViewModels in LIGHT BLUE, and Models in BROWN. We additionally have "Services" that are coded in ORANGE. 

![](img/arch.svg)

When the application [starts](MauiAppSample/App.xaml.cs), it [bootstraps](MauiAppSample/AppBootstrapper.cs) and then creates the [MainPage](MauiAppSample/Pages/MainPage.xaml).

The `MainPage` (and all other pages that are added to this application) derives from the [BasePage](MauiAppSample/Pages/BasePage.cs) so as to have a consistent feature access (such as logging, ViewModel associations, etc.) across all pages. As with any XAML application, `MainPage` comes with both [XAML](MauiAppSample/Pages/MainPage.xaml) and a [code-behind](MauiAppSample/Pages/MainPage.xaml.cs).

Both the XAML and its code-behind form a part of the "View" in the MVVM pattern. For ease of discovery, all pages (although are also views) are placed under a dedicated folder [Pages](MauiAppSample/Pages).


# Folders and files
The sample has the following folders and files (apart from the usual Visual Studio files):

Folder/File | Contents
----------- | ---------
App.xaml | Application front-end, having just a ListView a

