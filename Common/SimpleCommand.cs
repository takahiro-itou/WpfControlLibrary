//  -*-  coding: utf-8-with-signature  -*-  //
/*************************************************************************
**                                                                      **
**                  ---  WPF UserControl Library.  ---                  **
**                                                                      **
**          Copyright (C), 2026-2026, Takahiro Itou                     **
**          All Rights Reserved.                                        **
**                                                                      **
**          License: (See COPYING or LICENSE files)                     **
**          GNU Affero General Public License (AGPL) version 3,         **
**          or (at your option) any later version.                      **
**                                                                      **
*************************************************************************/

using System.ComponentModel;
using System.Windows.Input;


namespace  WpfControl.Common  {

//========================================================================
//
//    SimpleCommand  class.
//

public  class  SimpleCommand<T> : AbstractSimpleCommand
{

//========================================================================
//
//    Constructor(s) and Destructor.
//

//----------------------------------------------------------------
/**   コンストラクタ。
**
**/
public
SimpleCommand(
        Action<T>           execute,
        Predicate<object?>? canExecute = null)
    : base(canExecute)
{
    this.m_execute  = execute ?? throw new ArgumentNullException(
            nameof(execute));
}


//========================================================================
//
//    Public Member Functions (Implement Interface).
//

//----------------------------------------------------------------
/**
**
**/
public  override  void
Execute(object? parameter)
{
    T tparam = default(T);
    if (parameter is not null) {
        tparam = (parameter is T)
            ? (T)parameter
            : (T)s_typeConverter.ConvertFrom(parameter);
    }
    this.m_execute(tparam);
}

//========================================================================
//
//    Public Member Functions.
//

//----------------------------------------------------------------
/**   CanExecuteChanged イベントを発生させる。
**
**/
public  void
RaiseCanExecuteChanged()
{
    base.raiseCanExecuteChangedEvent();
}


//========================================================================
//
//    Member Variables.
//

/**   実行する内容。    **/
private  readonly   Action<T>       m_execute;

private  static     TypeConverter
    s_typeConverter = TypeDescriptor.GetConverter(typeof(T));

}   //  End class AbstractSampleViewModel

}   //  End of namespace  WpfControl.Sample
