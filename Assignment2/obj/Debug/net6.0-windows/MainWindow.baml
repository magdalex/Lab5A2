   M S B A M L   `   `   `  ????F  BAssignment2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment2Assignment2  5   	       Assignment2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment2     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5
   
   ?? -   5         ??Name$ productName1??5
      $??Product Name??6&   $
??Left=?6=   $??	59,61,0,0q?6X   $	??Top=?6k   $??20(?6?   ?? 5   
   -   5         ??Name$ productName??5      $
??Left=?6'   $??
239,69,0,0q?6B    ?? TextWrapping$
 Wrap=?6V   $	??Top=?6j   $	??120??6?   $??20(?6?   ?? 5   
   -   5        $ 
productID1??5      $??
Product ID??6$   $
??Left=?69   $??	59,27,0,0q?6T   $	??Top=?6g   $??20(?6   ?? 5   
   -   5        $ 	productID??5      $
??Left=?6%   $??
239,35,0,0q?6@   $
 Wrap=?6T   $	??Top=?6h   $	??120??6?   $??20(?6?   ?? 5   
   -   5        $ 	amountKG1??5      $??Amount (KG)??6#   $
??Left=?69   $??
59,128,0,0q?6T   $	??Top=?6h   $??20(?6?   ?? 5   
   -   5        $ amountKG??5      $
??Left=?6$   $??239,136,0,0q?6?   $
 Wrap=?6T   $	??Top=?6h   $	??120??6?   $??20(?6?   ?? 5   
   -   5        $ price1??5      $??Price(CAD)/kg??6    $
??Left=?68   $??	59,95,0,0q?6S   $	??Top=?6f   $??20(?6~   ?? 5   
   -   5        $ price??5      $
??Left=?6!   $??239,103,0,0q?6<   $
 Wrap=?6Q   $	??Top=?6e   $	??120??6}   $??20(?6?   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ dataGrid??5      $??27,199,229,38q?6P   ?? 5   
   -
   5         ??Name$ refreshDataButton??5      $??REFRESH DATA??6,   $
??Left=?6C   $??
629,64,0,0q?6^   $	??Top=?6r   6?   ?? 5   
   -   5        $ insertButton??5      $??INSERT??6'   $
??Left=?68   $??
655,98,0,0q?6S   $	??Top=?6g   6   ?? 5   
   -   5        $ updateButton??5      $??UPDATE??6'   $
??Left=?68   $??655,140,0,0q?6S   $	??Top=?6h   6?   ?? 5   
   -   5        $ deleteButton??5      $??DELETE??6'   $
??Left=?68   $??654,176,0,0q?6S   $	??Top=?6h   6?   ?? 5   
   -   5        $ connectButton??5      $??CONNECT??6(   $
??Left=?6:   $??
646,30,0,0q?6U   $	??Top=?6i   6?   ?? 5   
   -   5        $ 	addToCart??5      $??Add to Cart??6$   $
??Left=?6:   $??616,227,0,0q?6U   $	??Top=?6j   6?   ?? 5   
   -   5        $ 	goToSales??5      $??Go to Sales??6$   $
??Left=?6:   $??698,227,0,0q?6U   $	??Top=?6j   6?   5      5      