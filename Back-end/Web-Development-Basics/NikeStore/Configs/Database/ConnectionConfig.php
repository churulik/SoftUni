<?php
namespace NikeStore\Configs\Database;

class ConnectionConfig
{
    public static function db()
    {
        $db = new \mysqli (
            DatabaseConfig::DB_HOST,
            DatabaseConfig::DB_USER,
            DatabaseConfig::DB_PASS,
            DatabaseConfig::DB_NAME);

        return $db;
    }
}