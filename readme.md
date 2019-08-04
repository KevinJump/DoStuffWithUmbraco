# doStuffWithUmbraco<sup>8</sup>

A Collection of patterns and samples of how to do things in
umbraco 8.

this library is just a collection of things that I have needed
to do/explain/remember while developing sites and packages for
Umbraco, its by no means complete, but hopefully it's helpful.

# Snippets
- [Migrations](/Src/DoStuff.Core/Migrations)
- [Custom Sections](/Src/DoStuff.Core/Sections)
- [Dashboard](/Src/DoStuff.Core/App_Plugins/DoStuff.Dashboard)


## Structure
The Project consists of two mail elements 

### DoStuff.Core 
The Core library has all the code examples in, for things
like sections, migrations etc. you should be able to see 
how things work and lift them from this section.

*there is a gulp script to copy files from app_plugins to the site, so 
mostly everything is in this project.*

### DoStuff.Site
This is the umbraco site, mostly this is just a place 
for things to run, the code will be in the libraries. 



