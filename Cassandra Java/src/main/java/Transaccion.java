/**
 * Created by JuanCamilo on 6/11/2015.
 */

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.cassandra.mapping.Column;
import org.springframework.data.cassandra.mapping.PrimaryKey;
import org.springframework.data.cassandra.mapping.Table;

import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Table(value="transaccion")
public class Transaccion
{
    @PrimaryKey private int id;
    @Column private boolean cliente_mayorista;
    @Column private String observaciones;
    @Column private Date fecha;


}