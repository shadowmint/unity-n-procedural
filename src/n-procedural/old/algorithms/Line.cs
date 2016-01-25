using System;

namespace N.Package.Procedural {

  /// A line drawer interface
  public interface Line {

    /// Draw a line in value from x0, y0 to x1, y1
    void draw(int x0, int y0, int x1, int y1);
  }
}
