FROM mysql:5.7.22
EXPOSE 3306
COPY ./RESTWithASP-NET5/db/migrations/ /home/database/
COPY ./RESTWithASP-NET5/db/dataset/ /home/database/
COPY ./RESTWithASP-NET5/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh