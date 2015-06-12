import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.Date;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.data.cassandra.core.CassandraOperations;
import org.springframework.data.cassandra.core.CassandraTemplate;

import com.datastax.driver.core.Cluster;
import com.datastax.driver.core.Session;
import com.datastax.driver.core.querybuilder.QueryBuilder;
import com.datastax.driver.core.querybuilder.Select;

public class CassandraApp {

    private static final Logger LOG = LoggerFactory.getLogger(CassandraApp.class);

    private static Cluster cluster;
    private static Session session;

    public static void main(String[] args) {

            cluster = Cluster.builder().addContactPoints("127.0.0.1").build();

            session = cluster.connect("example");

            CassandraOperations cassandraOps = new CassandraTemplate(session);

            //cassandraOps.insert(new Transaccion(10, false, "Observacion java", new Date()));

            Select s = QueryBuilder.select("transaccion").from("transaccion");
            s.where(QueryBuilder.eq("id", 10));

            System.out.println(String.valueOf(cassandraOps.queryForObject(s, Integer.class)));
    }
}
