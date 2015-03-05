# FiddlerLoadBalancer
Fiddler script to emulate load balancer.

Sometimes we face some issues related to Load Balancing. On production we have Load Balancing to improve performance of our software. The problem is that on developer computer we don't have similar functionality. Developers only deal with one instance of site. But there is simple way to have something similar:

First of all you should create two copies of your site on IIS. It is easier than it may look like.
* Go to "c:\windows\system32\inetsrv\config". You may need administrator rights to do it.
* Open applicationHost.config file in any XML editor.
* Make a backup of this file (just in case)
* Find element <site name="name of your site" ... (e.g. "<site name="my-cool-site" ....)
* Copy this element and paste it twice after current element.
* For these two new elements change 'name' and 'id' attributes so that they don't overlap with existing sites.
* Inside these two new elements find <bindings> elements and modify ports of http binding so they don't overlap with existing sites.
* Save the file and restart IIS.

If everything is Ok now you should have 2 copies of your site.

Now Fiddler comes to play.
* Install Fiddler (http://www.telerik.com/fiddler)
* Add reference to Fiddler.exe to this project.
* Build the project.
* Copy resulting dll into <your-user-directory>\Documents\Fiddler2\Scripts.
* In IIS stop your initial site and run two copies.
* Start Fiddler.
* Open browser and connect to your site using address of your INITIAL site.

If everything is OK you will work with your site while requests will be sent to two copies of your site at random. I had some troubles during warming up of sites. But then I was able to work with them.

You may modify Balancer class and define any rules about where each request should go.


