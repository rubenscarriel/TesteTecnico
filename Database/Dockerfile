FROM mysql:8.0
MAINTAINER  Rubens Carriel <rubens.carriel@gmail.com>
ENV MYSQL_DATABASE TESTETECNICODB
ENV MYSQL_USER testetecnico
ENV MYSQL_PASSWORD admin123
EXPOSE 3306
COPY ./sql-scripts/setup.sql /docker-entrypoint-initdb.d/setup.sql