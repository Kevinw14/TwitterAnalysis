   M S B A M L   `   `   `  ????J  FTwitterAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TwitterAnalysisTwitterAnalysis  5   	   '    !TwitterAnalysis.TweetSearchWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TwitterAnalysis     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     ? Title$  TweetSearchWindow??5	   	   $	??450??6#   $	??800??60   .??5
      ?? .??5   
   ? -   5         ?Name$ 	ParamGrid??5      $??10,5,0,0q?6"    ? RowDefinitions 5      ?? 5      $
??auto ?6    60   ?? 5      $
??auto ?6    60   ?? 5      $
??auto ?6    60   ?? 5      $
??auto ?6    60    ? ColumnDefinitions 5      ?? 5      $
??auto ?6#   62   .+?5      ?? $??0??6   $??0??6)    ?? Orientation$ 
Horizontal=?66   .+?5      ?? -   5         ??Name$ ParamsComboBox??5      $
??Left=?63   $??Center=?6N   .@?5      ??  ?? 
IsSelected$
 True??6#   $??Query??65   6G   ?? 5      $??
Start Time??6#   ?? 5      $??End Time??6#   ?? 5      $??Max Results??6#   5      ?? 5      -   5        $??	AddButton??5   ?   $??30??6   $??10,0,0,0q?6$     FontAwesome.WPF.Awesome   Content$
 Plus=?66   $C??=pack://application:,,,/FontAwesome.WPF;component/#FontAwesome)?6P   6?   5      ?? 5      -   5         ??Name$ ExecuteButton??5      $??0??6,   $??4??6<   $??Execute??6I   ${?False??6w   5      5       5!      