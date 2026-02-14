import z from "zod";

export const UserSchemaResponse = z.object({
    id: z.guid(),
    firstName: z.string().min(3),
    secondName: z.string().min(3)
});

export const NewUserRequest = z.object({
    firstName: z.string().min(3),
    secondName: z.string().min(3)
})

export type User = z.infer<typeof UserSchemaResponse>;