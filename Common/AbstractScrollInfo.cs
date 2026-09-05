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

using   System.Windows.Controls;
using   System.Windows.Controls.Primitives;


namespace  WpfControl.Common  {


//========================================================================
//
//    AbstractScrollInfo  class.
//

public abstract class  AbstractScrollInfo : IScrollInfo
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
AbstractScrollInfo()
{
}


//========================================================================
//
//    Public Member Functions (Implement Interface).
//

public  virtual  void
LineDown()
{
}

public  virtual  void
LineLeft()
{
}

public  virtual  void
LineRight()
{
}

public  virtual  void
LineUp()
{
    SetVerticalOffset(this.VerticalOffset - this.SmallChangeY);
}


public  virtual  System.Windows.Rect
MakeVisible(
        System.Windows.Media.Visual visual,
        System.Windows.Rect         rectangle)
{
    return ( rectangle );
}


public  virtual  void
MouseWheelDown()
{
}

public  virtual  void
MouseWheelLeft()
{
}

public  virtual  void
MouseWheelRight()
{
}

public  virtual  void
MouseWheelUp()
{
}

public  virtual  void
PageDown()
{
}

public  virtual  void
PageLeft()
{
}

public  virtual  void
PageRight()
{
}

public  virtual  void
PageUp()
{
}


//----------------------------------------------------------------
/**
**
**/

public  virtual  void
SetHorizontalOffset(
        double  offset)
{
    double  val = Math.Max(0, Math.Min(
        offset, this.ExtentWidth - this.ViewportWidth));
    if ( this.m_scrollOffset.X != val ) {
        this.m_scrollOffset.X = val;
        invalidateScroll();
    }
}

//----------------------------------------------------------------
/**
**
**/

public  virtual  void
SetVerticalOffset(
        double  offset)
{
    double  val = Math.Max(0, Math.Min(
        offset, this.ExtentHeight - this.ViewportHeight));
    if ( this.m_scrollOffset.X != val ) {
        this.m_scrollOffset.X = val;
        invalidateScroll();
    }
}


//========================================================================
//
//    Properties (Implement Interface).
//

public  virtual  bool  CanHorizontallyScroll { get; set; }

public  virtual  bool  CanVerticallyScroll   { get; set; }


public  abstract double  ExtentHeight { get; }

public  abstract double  ExtentWidth  { get; }


public  virtual  double  HorizontalOffset {
    get { return  this.m_scrollOffset.X; }
}


public  virtual  ScrollViewer  ScrollOwner
{
    get { return  this.m_scrollOwner; }
    set { this.m_scrollOwner = value; }
}


public  virtual  double  VerticalOffset {
    get { return  this.m_scrollOffset.Y; }
}


public  virtual  double  ViewportHeight {
    get { return  this.m_viewport.Height; }
}

public  virtual  double  ViewportWidth {
    get { return  this.m_viewport.Width; }
}


public  virtual  double  SmallChangeX { get; set; } = 1.0;

public  virtual  double  SmallChangeY { get; set; } = 1.0;


//========================================================================
//
//    Protected Member Functions (Overrides).
//


//========================================================================
//
//    Protected Member Functions.
//

//----------------------------------------------------------------
/**
**
**/

protected  abstract  void  refreshViewport();

//----------------------------------------------------------------
/**
**
**/

protected  virtual  void
invalidateScrollView()
{
    this.m_scrollOwner?.InvalidateScrollInfo();
    refreshViewport();
}


//========================================================================
//
//    Member Variables.
//

private   System.Windows.Size   m_viewport;

private   System.Windows.Point  m_scrollOffset;

private   ScrollViewer          m_scrollOwner;

}   //  End class  AbstractScrollInfo

}   //  End of namespace  WpfControl.Common
