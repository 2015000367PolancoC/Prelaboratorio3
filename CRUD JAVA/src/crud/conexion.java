package crud;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import javax.swing.JOptionPane;
public class conexion {
     public static String DRIVER = "com.mysql.jdbc.Driver";
    public static String USUARIO = "root";
    public static String PASSWORD = "";
    public static String URL = "jdbc:mysql://localhost:3306/construccionesIXCOT";

    static{
        try{
            Class.forName(DRIVER);
        }
        catch(ClassNotFoundException e){
            JOptionPane.showMessageDialog(null,"Error en el driver "+e);
        }
    }
        public Connection getConnection(){
         Connection conexion = null;

         try{
           conexion = DriverManager.getConnection(URL, USUARIO, PASSWORD);
        }catch(SQLException e){
            JOptionPane.showMessageDialog(null, "Error en la conexion "+e);
        }
            return conexion;


        }
}
