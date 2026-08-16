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

using ExecPred = Predicate<object>

namespace  WpfControl.Common  {

//========================================================================
//
//    AbstractSimpleCommand  class.
//

public abstract class  AbstractSimpleCommand : ICommand
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
AbstractSimpleCommand(
        ExecPred?   canExecute = null)
{
    this.m_canExec  = canExecute;
}


//========================================================================
//
//    Public Member Functions (Pure Virtual Functions).
//

//----------------------------------------------------------------
/**
**
**/
public  abstract  void
Execute(object? parameter);


//========================================================================
//
//    Public Member Functions (Implement Interface).
//

//----------------------------------------------------------------
/**   コマンドが実行可能か否かを返す。
**
**/
public  bool
CanExecute(object? parameter)
{
    return ( this.m_canExecute?.Invoke(parameter) ?? true );
}


//========================================================================
//
//    Public Events (Implement Interface).
//

//----------------------------------------------------------------
/**
**
**/
public  event   EventHandler?   CanExecuteChanged;


//========================================================================
//
//    Public Member Functions.
//

//----------------------------------------------------------------
/**   CanExecuteChanged イベントを発生させる。
**
**/
public  virtual  void
raiseCanExecuteChangedEvent()
{
    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

//----------------------------------------------------------------
/**   CanExecuteChanged イベントを発生させる。
**
**/
public  void
RaiseCanExecuteChanged()
{
    raiseCanExecuteChangedEvent();
}


//========================================================================
//
//    Member Variables.
//

/**   実行可否の判定。  **/
private  readonly   ExecPred?   m_canExecute;


}   //  End class  AbstractSimpleCommand

}   //  End of namespace  WpfControl.Common
