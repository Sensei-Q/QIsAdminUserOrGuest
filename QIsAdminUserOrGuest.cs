// QIsAdminUserOrGuest v1.0 (c) 2022 Sensei (aka 'Q')
// Checks if we are in the administrator, authenticated user or guest user group.
//
// Usage:
// QIsAdminUserOrGuest
//
// Compilation:
// %SYSTEMROOT%\Microsoft.NET\Framework\v3.5\csc QIsAdminUserOrGuest.cs
//
// Example:
// QIsAdminUserOrGuest
//
// Returns:
// 1 - if administrator
// 0 - if user
// -1 - if guest

using System;
using System.Diagnostics;
using System.Security;
using System.Security.Principal;
using System.Threading;

public class QIsAdminUserOrGuest {
   public static void Main( string [] args ) {
      WindowsIdentity current = WindowsIdentity.GetCurrent();
      if( current.IsAuthenticated ) {
         AppDomain domain = Thread.GetDomain();
         domain.SetPrincipalPolicy( PrincipalPolicy.WindowsPrincipal );
         WindowsPrincipal principal = (WindowsPrincipal) Thread.CurrentPrincipal;
         if( principal.IsInRole( "BUILTIN\\Administrators" ) ) {
            Console.WriteLine( "1" );
         } else {
            Console.WriteLine( "0" );
         }
      } else {
         Console.WriteLine( "-1" );
      }
   }
}
