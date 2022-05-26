--Part 1
SELECT COLUMNS FROM employers;
SELECT COLUMNS FROM jobs;
SELECT COLUMNS FROM jobskill;
SELECT COLUMNS FROM skills;


--Part 2
SELECT * FROM techjobs.employers WHERE techjobs.employers.Location = "St Louis";

--Part 3
SELECT Name FROM techjobs.skills INNER JOIN jobskills ON jobskills.SkillId = skills.Id WHERE jobskills.JobId IS NOT NULL ORDER BY Name;

