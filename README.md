### docker安装MySQL

1. 拉取MySQL镜像

   `docker pull mysql:5.7`MySQL5.7版本

   `docker pull mysql:latest`最新版本

   

2. 创建容器，主库

   `docker run --name mysql-master -p 3307:3306 -v /0982/master:/etc/mysql/mysql.conf.d -e MYSQL_ROOT_PASSWORD=123456 -d mysql:5.7 `

   以MySQL5.7镜像创建MySQL容器并挂载配置文件目录到/etc/mysql/mysql.conf.d,端口号为3307

3. mysql.cof配置文件更改，末尾添加

   `log-bin=mysql-bin`

   `server-id=2`

4. 创建从库

5. 从库配置文件修改

   `server-id=4` id要比主库大

   `default-storage-engine=MyISAM` 修改数据库引擎,使查询效率更高

### 配置主库

1. 进入容器

   `docker exec -it mysql-master /bin/bash`

   连接MySQL

   `mysql -u root -p 123456`

   查看日志信息

   `show master status`

   

   



