/*
 Navicat MySQL Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : localhost:3306
 Source Schema         : guangjuqili

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 29/08/2019 16:30:37
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sys_uuid
-- ----------------------------
DROP TABLE IF EXISTS `sys_uuid`;
CREATE TABLE `sys_uuid`  (
  `uuid` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `count` int(11) NULL DEFAULT NULL,
  `money` float NULL DEFAULT NULL,
  `comment` tinyint(1) NULL DEFAULT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_uuid
-- ----------------------------
INSERT INTO `sys_uuid` VALUES ('02a7bc09-f5b4-4d72-ba08-b9ef43facf50', 'aa', 0, 1000, 0);
INSERT INTO `sys_uuid` VALUES ('122c99c6-cd1f-4fe7-95d5-1904e4c1cb4d', 'aa', 0, 1000, 0);
INSERT INTO `sys_uuid` VALUES ('13d85c35-3a7c-410f-bfa7-59d85472c3fb', 'aa', 0, 1000, 0);
INSERT INTO `sys_uuid` VALUES ('95ae42a3-f5a4-4941-b1ab-ae2cc17208c6', 'aa', 0, 1000, 0);
INSERT INTO `sys_uuid` VALUES ('f0dcd068-8f4f-480f-97ca-dbcb0e513856', 'aa', 0, 1000, 0);

-- ----------------------------
-- Table structure for sysdept
-- ----------------------------
DROP TABLE IF EXISTS `sysdept`;
CREATE TABLE `sysdept`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Manager` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EmpNumber` int(11) NULL DEFAULT NULL,
  `Money` float NULL DEFAULT NULL,
  `Comment` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `modifytime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysdept
-- ----------------------------
INSERT INTO `sysdept` VALUES (1, '政治部', '', 0, 0, '', NULL);
INSERT INTO `sysdept` VALUES (2, '外交部', '', 0, 0, '', NULL);
INSERT INTO `sysdept` VALUES (3, '国防部', '', 0, 0, '', '2019-08-09 14:18:24');
INSERT INTO `sysdept` VALUES (4, '教育部', '', 0, 0, '', '2019-08-09 15:05:16');
INSERT INTO `sysdept` VALUES (5, '科学技术部', '', 0, 0, '', '2019-08-09 15:13:16');
INSERT INTO `sysdept` VALUES (6, '工业和信息化部', '', 0, 0, '', '2019-08-09 15:18:35');
INSERT INTO `sysdept` VALUES (7, '公安部', '', 0, 0, '', '2019-08-09 15:40:08');
INSERT INTO `sysdept` VALUES (8, '监察部', '', 0, 0, '', '2019-08-09 15:43:02');
INSERT INTO `sysdept` VALUES (9, '民政部', '', 0, 0, '', '2019-08-09 15:46:11');
INSERT INTO `sysdept` VALUES (10, '住房和城乡建设部', '', 0, 0, '', '2019-08-09 15:59:53');
INSERT INTO `sysdept` VALUES (11, '交通运输部', '', 0, 0, '', '2019-08-14 10:50:14');
INSERT INTO `sysdept` VALUES (12, '水利部', '', 0, 0, '', '2019-08-14 10:53:32');
INSERT INTO `sysdept` VALUES (13, '农业部', '', 0, 0, '', '2019-08-14 10:53:44');
INSERT INTO `sysdept` VALUES (14, '商务部', '', 0, 0, '', '2019-08-14 10:55:43');
INSERT INTO `sysdept` VALUES (15, '文化部', '', 0, 0, '', '2019-08-14 10:56:36');
INSERT INTO `sysdept` VALUES (16, 'aaa6667a8d4-e1e9-43c6-95f7-cd3706a35d192019-08-14 11:40:03', '', 0, 0, '', '2019-08-14 11:41:05');
INSERT INTO `sysdept` VALUES (17, 'aaa2f8b952c-c02a-4a6b-a30b-f68d6f9d867d', '', 0, 0, '', '2019-08-14 11:42:04');
INSERT INTO `sysdept` VALUES (18, 'aaa71284913-c928-4939-a04b-dd4408ebe24a', '', 0, 0, '', '2019-08-14 11:42:45');
INSERT INTO `sysdept` VALUES (19, 'aaac9017b0a-ce5b-47cb-b209-c3b12fa589012019-08-14 11:49:31', '', 0, 0, '', '2019-08-14 11:50:38');
INSERT INTO `sysdept` VALUES (20, 'aaaf9b9775d-45ea-4c48-be04-69403399ba0b2019-08-14 16:16:08', '', 0, 0, '', '2019-08-14 16:16:24');
INSERT INTO `sysdept` VALUES (21, 'aaaf793b227-ee55-482c-b6fd-05ec50e91297', '', 0, 0, '', '2019-08-15 15:46:15');
INSERT INTO `sysdept` VALUES (22, 'aaa5635b320-d7be-4caa-8144-4d5ecaddd1da', '', 0, 0, '', '2019-08-15 15:50:24');
INSERT INTO `sysdept` VALUES (23, 'aaab3694dad-9f6c-4546-85b1-6e1ad278fa75', '', 0, 0, '', '2019-08-15 15:54:31');

-- ----------------------------
-- Table structure for sysuser
-- ----------------------------
DROP TABLE IF EXISTS `sysuser`;
CREATE TABLE `sysuser`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `sex` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `fk_deptid` int(11) NULL DEFAULT NULL,
  `address` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `girlfriend` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `fk_deptid`(`fk_deptid`) USING BTREE,
  CONSTRAINT `fk_deptid` FOREIGN KEY (`fk_deptid`) REFERENCES `sysdept` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysuser
-- ----------------------------
INSERT INTO `sysuser` VALUES (1, 'aa33692', '', 1, '', '');
INSERT INTO `sysuser` VALUES (2, 'aa76125', '', 1, '', '');
INSERT INTO `sysuser` VALUES (3, 'aa42660', '', 2, '', '');
INSERT INTO `sysuser` VALUES (4, 'aa56475', '', 3, '', '');
INSERT INTO `sysuser` VALUES (5, 'aa31643', '', 4, '', '');
INSERT INTO `sysuser` VALUES (6, 'aa6811', '', 5, '', '');
INSERT INTO `sysuser` VALUES (7, 'aa97178', '', 6, '', '');
INSERT INTO `sysuser` VALUES (8, 'aa36824', '', 7, '', '');
INSERT INTO `sysuser` VALUES (9, 'aa83036', '', 8, '', '');
INSERT INTO `sysuser` VALUES (10, 'aa38881', '', 9, '', '');
INSERT INTO `sysuser` VALUES (11, 'aa77528', '', 10, '', '');

-- ----------------------------
-- View structure for v_a1
-- ----------------------------
DROP VIEW IF EXISTS `v_a1`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `v_a1` AS select `a1`.`id` AS `id`,`a1`.`name` AS `name`,`a1`.`sex` AS `sex`,`a1`.`address` AS `address`,`a1`.`girlfriend` AS `girlfriend`,`a2`.`Name` AS `dept_name`,`a2`.`Manager` AS `Manager`,`a2`.`EmpNumber` AS `EmpNumber` from (`sysdept` `a2` join `sysuser` `a1`) where (`a1`.`fk_deptid` = `a2`.`id`);

SET FOREIGN_KEY_CHECKS = 1;
